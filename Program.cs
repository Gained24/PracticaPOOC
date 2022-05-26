using AplicacionSeguros;

//ESTRUCTURAS DE CONTROL
Dictionary<string, Persona> diccionario_personas = new Dictionary<string, Persona>();
Dictionary<string, Empresa> diccionario_empresas = new Dictionary<string, Empresa>();
Dictionary<int, Poliza> diccionario_polizas = new Dictionary<int, Poliza>();
Dictionary<int, DatosRecibos> diccionario_recibos = new Dictionary<int, DatosRecibos>();
Dictionary<string, DatosSiniestro> diccionario_siniestros = new Dictionary<string, DatosSiniestro>();

//VARIABLES GLOBALES
string year_siniestro = "0";
string numero_siniestro = "0";

//FUNCIÓN PARA CREAR UNA PERSONA Y LA AÑADE AL DICCIONARIO
Persona CrearPersona()
{
    Console.Write("Introduzca dni: ");
    string dni = Console.ReadLine();
    if (!diccionario_personas.ContainsKey(dni))
    {
        Console.Write("Introduzca nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Introduzca telefono: ");
        string telefono = Console.ReadLine();
        Console.Write("Introduzca fecha de nacimiento: ");
        string fecha_nacimiento = Console.ReadLine();
        Persona persona = new Persona(nombre, dni, fecha_nacimiento, telefono);
        diccionario_personas.Add(dni, persona);
        return persona;
    }
    else
    {
        Console.WriteLine("La persona ya estaba añadida. Se añadirá con sus datos.");
        diccionario_personas.TryGetValue(dni, out Persona persona);
        diccionario_personas.Add(dni, persona);
        return persona;
    }
}
//FUNCÓN PARA CREAR UNA EMPRESA Y LA AÑADE AL DICCIONARIO
Empresa CrearEmpresa()
{
    Console.WriteLine("\nCREACIÓN DE EMPRESA");
    Console.Write("Introduzca cif: ");
    string cif = Console.ReadLine();
    Console.Write("Nombre de la empresa: ");
    string nombre = Console.ReadLine();
    Console.Write("Teléfono de la empresa: ");
    string telefono = Console.ReadLine();
    Console.Write("¿El responsable está registrado?(S/N)");
    string eleccion_responsable = Console.ReadLine().ToUpper();
    if (eleccion_responsable == "N")
    {
        Persona persona = CrearPersona();
        Empresa empresa = new Empresa(nombre, cif, persona, persona.ObtenerNIF(), telefono);
        diccionario_empresas.Add(cif, empresa);
        return empresa;
    }
    else
    {
        Console.Write("Introduzca dni: ");
        string dni = Console.ReadLine();
        if (diccionario_personas.ContainsKey(dni))
        {
            diccionario_personas.TryGetValue(dni, out Persona persona);
            Empresa empresa = new Empresa(nombre, cif, persona, persona.ObtenerNIF(), telefono);
            diccionario_empresas.Add(cif, empresa);
            return empresa;
        }
        else
        {
            Console.Write("La persona no estaba añadida. Introduzca los datos de una nueva persona:");
            Persona persona = CrearPersona();
            Empresa empresa = new Empresa(nombre, cif, persona, persona.ObtenerNIF(), telefono);
            diccionario_empresas.Add(cif, empresa);
            return empresa;
        }
    }
}
//FUNCIÓN QUE REALIZA EL FLUJO DE CREAR UNA POLIZA Y LA AÑADE AL DICCIONARIO
void CrearPoliza()
{
    Console.Write("Introduzca número de poliza: ");
    int numero = Convert.ToInt32(Console.ReadLine());
    if (diccionario_polizas.ContainsKey(numero))
    {
        Console.WriteLine("La poliza ya existe.");
    }
    else
    {
        Console.Write("¿El tomador será empresa o persona?(E/P): ");
        string tipo = Console.ReadLine().ToUpper();
        if (tipo == "E")
        {
            Console.Write("Introduzca cif de la empresa: ");
            string cif= Console.ReadLine();
            if (!diccionario_empresas.ContainsKey(cif))
            {
                Console.Write("La empresa no existe. ¿Desea crearla?(S/N):");
                string eleccion_empresa = Console.ReadLine().ToUpper();
                if (eleccion_empresa == "N")
                {
                    return;
                }
                else
                {
                    Empresa empresa = CrearEmpresa();
                    Console.Write("Introduzca fecha de efecto de la poliza: ");
                    string fecha_efecto = Console.ReadLine();
                    Poliza poliza = new Poliza(numero, empresa, fecha_efecto);
                    diccionario_polizas.Add(numero, poliza);
                }
            }
            else
            {
                diccionario_empresas.TryGetValue(cif, out Empresa empresa);
                Console.Write("Introduzca fecha de efecto de la poliza: ");
                string fecha_efecto = Console.ReadLine();
                Poliza poliza = new Poliza(numero, empresa, fecha_efecto);
                diccionario_polizas.Add(numero, poliza);
            }

        }
        if (tipo == "P")
        {
            Console.Write("Introduzca dni de la persona: ");
            string dni = Console.ReadLine();
            if (!diccionario_personas.ContainsKey(dni))
            {
                Console.Write("La persona no está añadida. ¿Desea añadirla?(S/N):");
                string eleccion_persona = Console.ReadLine().ToUpper();
                if (eleccion_persona == "N")
                {
                    return;
                }
                else
                {
                    Persona persona = CrearPersona();
                    Console.Write("Introduzca fecha de efecto de la poliza: ");
                    string fecha_efecto = Console.ReadLine();
                    Poliza poliza = new Poliza(numero, persona, fecha_efecto);
                    diccionario_polizas.Add(numero, poliza);
                }
            }
            else
            {
                diccionario_personas.TryGetValue(dni, out Persona persona);
                Console.Write("Introduzca fecha de efecto de la poliza: ");
                string fecha_efecto = Console.ReadLine();
                Poliza poliza = new Poliza(numero, persona, fecha_efecto);
                diccionario_polizas.Add(numero, poliza);
                
            }
        }
        
    }
}
//CREA O MODIFICA UN RECIBO, SI LO CREA LO AÑADE AL DICCIONARIO SI LO MODIFICA CAMBIA SU ESTADO Y LE AÑADE UNA FECHA DE LIQUIDACIÓN
void CrearModificarRecibo()
{
    Console.WriteLine("\nRECIBOS\n1. CrearReacibo.\n2. ModificarEstadoReciboADevuelto.\n3. ModificarEstadoReciboACobrado\n4. Salir\n");
    Console.Write("-> ");
    int opt = Convert.ToInt32(Console.ReadLine());

    switch (opt)
    {
        case 1:
            Console.Write("Introduzca el número del recibo: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_recibos.ContainsKey(numero))
            {
                Console.Write("Introduzca el número de la poliza: ");
                int numero_poliza = Convert.ToInt32(Console.ReadLine());
                if (diccionario_polizas.ContainsKey(numero_poliza))
                {
                    Console.Write("Introduzca fecha de la emisión del recibo: ");
                    string fecha_emision = Console.ReadLine();
                    Console.Write("Importe del seguro: ");
                    int importe = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Comisión: ");
                    int comision = Convert.ToInt32(Console.ReadLine());
                    if (comision < importe)
                    {
                        DatosRecibos recibos = new DatosRecibos(numero_poliza, numero, fecha_emision, importe, comision);
                        diccionario_recibos.Add(numero, recibos);
                    }
                    else
                    {
                        Console.WriteLine("La comisión no puede ser igual o mayor al importe.\n");
                    }
                    
                }
                else
                {
                    Console.WriteLine("La poliza no existe.\n");
                }  
            }
            else
            {
                Console.WriteLine("El recibo ya existe.\n");
            }
            break;
        case 2:
            Console.Write("Introduzca el número del recibo: ");
            int numero_buscar = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_recibos.ContainsKey(numero_buscar))
            {
                Console.WriteLine("El recibo no existe.\n");
            }
            else
            {
                diccionario_recibos.TryGetValue(numero_buscar, out DatosRecibos recibos);
                recibos.CambiarEstadoADevuelto();
            }
            break;
        case 3:
            Console.Write("Introduzca el número del recibo: ");
            int numero_buscar2 = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_recibos.ContainsKey(numero_buscar2))
            {
                Console.WriteLine("El recibo no existe.\n");
            }
            else
            {
                diccionario_recibos.TryGetValue(numero_buscar2, out DatosRecibos recibos);
                recibos.CambiarEstadoACobrado();
            }
            break;
        case 4:
            break;
        default:
            Console.WriteLine("\n\nLa opción no es válida. Volviendo...\n\n");
            break;
    }
}
//CREA UN SINIESTRO Y PERMITE AÑADIR FECHA DE PAGO Y FECHA DE MODIFICACIÓN.
void CrearSiniestro()
{
    Console.WriteLine("\nSINIESTROS\n1. CrearSiniestros.\n2. AñadirFechaPago.\n3. Salir.\n");
    Console.Write("-> ");
    int opt = Convert.ToInt32(Console.ReadLine());

    switch (opt)
    {
        case 1:
            bool seguir = true;
            Console.Write("Introduzca año para registro del número de siniestro: ");
            string numero = Console.ReadLine();
            if (numero == year_siniestro)
            {
                numero_siniestro = Convert.ToString(Convert.ToInt32(numero_siniestro) + 1);
            }
            else if (Convert.ToInt32(numero) > Convert.ToInt32(year_siniestro))
            {
                year_siniestro = numero;
                numero_siniestro = "1";
            }
            else if (Convert.ToInt32(numero) < Convert.ToInt32(year_siniestro))
            {
                Console.WriteLine("\n\nEl dato está anticuado. Volviendo...\n\n");
                seguir = false;
            }
            Console.WriteLine("El número del siniestro es: " + numero + "-" + numero_siniestro);
            if (seguir)
            {
                if (!diccionario_siniestros.ContainsKey(numero))
                {
                    Console.Write("Introduzca el número de la poliza: ");
                    int numero_poliza = Convert.ToInt32(Console.ReadLine());
                    if (diccionario_polizas.ContainsKey(numero_poliza))
                    {
                        Console.Write("Introduzca cia: ");
                        string cia = Console.ReadLine();
                        Console.Write("¿La poliza contraria también es de la misma empresa?(S/N): ");
                        string empresa_propia = Console.ReadLine().ToUpper();
                        if (empresa_propia == "S")
                        {
                            Console.Write("Introduzca el número de la poliza contraria(ya registrado): ");
                            int poliza_contraria = Convert.ToInt32(Console.ReadLine());
                            if (diccionario_polizas.ContainsKey(numero_poliza) && poliza_contraria != numero_poliza)
                            {
                                Console.Write("Introduzca la matrícula contraria: ");
                                string matricula_contraria = Console.ReadLine();
                                DatosSiniestro siniestro = new DatosSiniestro(numero + "-" + numero_siniestro, numero_poliza, cia, poliza_contraria, true, matricula_contraria);
                                diccionario_siniestros.Add(numero, siniestro);
                            }
                            else if (diccionario_polizas.ContainsKey(numero_poliza) && poliza_contraria == numero_poliza)
                            {
                                Console.WriteLine("La poliza contraria no puede ser igual a la propia.\n");
                            }
                            else
                            {
                                Console.WriteLine("La poliza no existe.\n");
                            }
                        }
                        else if (empresa_propia == "N")
                        {
                            Console.Write("Introduzca el número de la poliza contraria: ");
                            int poliza_contraria = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Introduzca la matrícula contraria: ");
                            string matricula_contraria = Console.ReadLine();
                            DatosSiniestro siniestro = new DatosSiniestro(numero + "-" + numero_siniestro, numero_poliza, cia, poliza_contraria, false, matricula_contraria);
                            diccionario_siniestros.Add(numero + "-" + numero_siniestro, siniestro);
                        }
                        else
                        {
                            Console.WriteLine("\n\nLa opción no es válida. Volviendo...\n\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("La poliza no existe.\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("El siniestro ya existe.\n");
            }
            break;
        case 2:
            Console.Write("Introduzca el número del siniestro: ");
            string numero_buscar = Console.ReadLine();
            if (!diccionario_siniestros.ContainsKey(numero_buscar))
            {
                Console.WriteLine("El siniestro no existe.\n");
            }
            else
            {
                diccionario_siniestros.TryGetValue(numero_buscar, out DatosSiniestro siniestro);
                Console.Write("Introduzca fecha de pago del siniestro: ");
                string fecha_pago = Console.ReadLine();
                Console.Write("Introduzca importe del siniestro: ");
                int importe = Convert.ToInt32(Console.ReadLine());
                siniestro.AgregarImporteSiniestro(importe);
            }
            break;
        case 3:
            break;
        default:
            Console.WriteLine("\n\nLa opción no es válida. Volviendo...\n\n");
            break;
    }
}


void ImprimirLiquidar()
{
    //OBTENEMOS TODOS LOS RECIBOS COBRADOS y DEVUELTOS PERO SIN FECHA DE LIQUIDACIÓN.
    List<DatosRecibos> Lista_Recibidos = new List<DatosRecibos>();
    List<DatosRecibos> Lista_Devueltos = new List<DatosRecibos>();
    int suma_importe = 0;
    int suma_comision = 0;
    foreach (DatosRecibos item in diccionario_recibos.Values)
    {
        if (item.ObtenerEstado() == "cobrado" && item.ObtenerFechaLiquidacion() == "")
            {
            Lista_Recibidos.Add(item);
            suma_importe += item.Importe();
            suma_comision += item.Comision();

            }
        else if (item.ObtenerEstado() == "devuelto" && item.ObtenerFechaLiquidacion() == "")
            Lista_Devueltos.Add(item);
    }

    //OBTENEMOS TODOS LOS SINIESTROS PAGADOS PERO SIN FECHA DE LIQUIDACIÓN.
    List<DatosSiniestro> Lista_Siniestros = new List<DatosSiniestro>();
    int suma_siniestros = 0;
    foreach (DatosSiniestro item in diccionario_siniestros.Values)
    {
        if (item.ObtenerFechaPago() != "" && item.ObtenerFechaLiquidacion() == "")
            Lista_Siniestros.Add(item);
            suma_siniestros += item.Importe();
    }

    //IMPRIMIR
    //Cobrados.
    Console.WriteLine("---------------------------------\nRECIBOS COBRADOS:");
    foreach (DatosRecibos item in Lista_Recibidos)
    {
        Console.WriteLine($"Nro de poliza:{item.NroPoliza()} Nro de recibo:{item.NroRecibo()} Importe:{item.Importe()} Comision:{item.Comision()}");
    }
    Console.WriteLine($"TOTAL IMPORTE: {suma_importe}\nTOTAL COMISION:{suma_comision}");
    //devueltos
    Console.WriteLine("---------------------------------\nRECIBOS DEVUELTOS:");
    foreach (DatosRecibos item in Lista_Devueltos)
    {
        Console.WriteLine($"Nro de poliza:{item.NroPoliza()} Nro de recibo:{item.NroRecibo()} Importe:{item.Importe()} Comision:{item.Comision()}");
    }
    //siniestros
    Console.WriteLine("---------------------------------\nSINIESTROS:");
    foreach (DatosSiniestro item in Lista_Siniestros)
    {
        Console.WriteLine($"Nro de poliza:{item.NroPoliza()} Nro de siniestro:{item.NroSiniestro()} Importe Abonado:{item.Importe()}");
    }
    Console.WriteLine($"TOTAL IMPORTE ABONADO: {suma_siniestros}");
    Console.WriteLine("---------------------------------");
    Console.Write("¿Desea Liquidar todo? SI/NO: ");
    if (Console.ReadLine().ToUpper() == "SI")
    {
        Console.Write("Introduce la fecha de liquidacion: ");
        string fecha = Console.ReadLine();
        foreach (DatosRecibos item in Lista_Recibidos)
        {
            item.AgregarFechaLiquidacion(fecha);
        }
        foreach (DatosRecibos item in Lista_Devueltos)
        {
            item.AgregarFechaLiquidacion(fecha);
        }
        foreach (DatosSiniestro item in Lista_Siniestros)
        {
            item.AgregarFechaLiquidacion(fecha);
        }

        Console.WriteLine($"TOTAL LIQUIDACIÓN: {suma_importe - suma_comision - suma_siniestros}");
    }
    else {
        Lista_Siniestros.Clear();
        Lista_Devueltos.Clear();
        Lista_Recibidos.Clear();
    }

}

//PRINCIPAL
bool salir = false;
while (true)//MENÚ
{
    Console.WriteLine("\nGESTORSEGUROS\n1. CrearPoliza.\n2. Recibos.\n3. Siniestros.\n4. Liquidaciones.\n5. ListadoRecibos.\n6. Salir.\n");
    Console.Write("-> ");
    int opt = Convert.ToInt32(Console.ReadLine());

    switch (opt)
    {
        case 1:
            CrearPoliza();
            break;
        case 2:
            CrearModificarRecibo();
            break;
        case 3:
            CrearSiniestro();
            break;
        case 4:
            ImprimirLiquidar();
            break;
        case 5:
            break;
        case 6:
            salir = true;
            break;
        default:
            Console.WriteLine("\n\nElija una opción válida.\n\n");
            break;
    }
    if (salir) break;
}