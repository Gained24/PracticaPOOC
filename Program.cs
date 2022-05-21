using AplicacionSeguros;
//ESTRUCTURAS DE CONTROL
Dictionary<string, Persona> diccionario_personas = new Dictionary<string, Persona>();
Dictionary<string, Empresa> diccionario_empresas = new Dictionary<string, Empresa>();
Dictionary<int, Poliza> diccionario_polizas = new Dictionary<int, Poliza>();
Dictionary<int, DatosRecibos> diccionario_recibos = new Dictionary<int, DatosRecibos>();
Dictionary<int, DatosSiniestro> diccionario_siniestros = new Dictionary<int, DatosSiniestro>();
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
                    Console.Write("Introduzca estado de la poliza(vigor, ptellegar, baja): ");
                    string estado = Console.ReadLine().ToLower();
                    if (estado == "vigor" || estado == "ptllegar" || estado == "baja")
                    {
                        Poliza poliza = new Poliza(numero, empresa, fecha_efecto, estado);
                        diccionario_polizas.Add(numero, poliza);
                    }
                    else
                    {
                        Console.WriteLine("Error al introducir el estado.");
                    }
                }
            }
            else
            {
                diccionario_empresas.TryGetValue(cif, out Empresa empresa);
                Console.Write("Introduzca fecha de efecto de la poliza: ");
                string fecha_efecto = Console.ReadLine();
                Console.Write("Introduzca estado de la poliza(vigor, ptellegar, baja): ");
                string estado = Console.ReadLine().ToLower();
                if (estado == "vigor" || estado == "ptllegar" || estado == "baja")
                {
                    Poliza poliza = new Poliza(numero, empresa, fecha_efecto, estado);
                    diccionario_polizas.Add(numero, poliza);
                }
                else
                {
                    Console.WriteLine("Error al introducir el estado.");
                }
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
                    Console.Write("Introduzca estado de la poliza(vigor, ptellegar, baja): ");
                    string estado = Console.ReadLine().ToLower();
                    if (estado == "vigor" || estado == "ptllegar" || estado == "baja")
                    {
                        Poliza poliza = new Poliza(numero, persona, fecha_efecto, estado);
                        diccionario_polizas.Add(numero, poliza);
                    }
                    else
                    {
                        Console.WriteLine("Error al introducir el estado.");
                    }
                }
            }
            else
            {
                diccionario_personas.TryGetValue(dni, out Persona persona);
                Console.Write("Introduzca fecha de efecto de la poliza: ");
                string fecha_efecto = Console.ReadLine();
                Console.Write("Introduzca estado de la poliza(vigor, ptellegar, baja): ");
                string estado = Console.ReadLine().ToLower();
                if (estado == "vigor" || estado == "ptllegar" || estado == "baja")
                {
                    Poliza poliza = new Poliza(numero, persona, fecha_efecto, estado);
                    diccionario_polizas.Add(numero, poliza);
                }
                else
                {
                    Console.WriteLine("Error al introducir el estado.");
                }
            }
        }
        
    }
}
//CREA O MODIFICA UN RECIBO, SI LO CREA LO AÑADE AL DICCIONARIO SI LO MODIFICA CAMBIA SU ESTADO Y LE AÑADE UNA FECHA DE LIQUIDACIÓN
void CrearModificarRecibo()
{
    Console.WriteLine("\nRECIBOS\n1. CrearReacibo.\n2. ModificarEstadoRecibo.\n3. Salir.\n");
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
                    DatosRecibos recibos = new DatosRecibos(numero_poliza, numero, fecha_emision, importe, comision);
                    diccionario_recibos.Add(numero, recibos);
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
                recibos.EsDevuelto();
                Console.Write("Introduzca fecha de liquidación del recibo: ");
                string fecha_liquidacion = Console.ReadLine();
                recibos.AgregarFechaLiquidacion(fecha_liquidacion);
            }
            break;
        case 3:
            break;
        default:
            Console.WriteLine("\n\nLa opción no es válida. Volviendo...\n\n");
            break;
    }
}
//CREA UN SINIESTRO Y PERMITE AÑADIR FECHA DE PAGO Y FRCHA DE MODIFICACIÓN.
void CrearSiniestro()
{
    Console.WriteLine("\nSINIESTROS\n1. CrearSiniestros.\n2. AñadirFechaPago.\n3. AñadirFechaLiuidación.\n4. Salir.\n");
    Console.Write("-> ");
    int opt = Convert.ToInt32(Console.ReadLine());

    switch (opt)
    {
        case 1:
            Console.Write("Introduzca el número del siniestro: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_siniestros.ContainsKey(numero))
            {
                Console.Write("Introduzca el número de la poliza: ");
                int numero_poliza = Convert.ToInt32(Console.ReadLine());
                if (diccionario_polizas.ContainsKey(numero_poliza))
                {
                    Console.Write("Introduzca cia: ");
                    string cia = Console.ReadLine();
                    Console.Write("Introduzca el número de la poliza contraria: ");
                    int poliza_contraria = Convert.ToInt32(Console.ReadLine());
                    if (diccionario_polizas.ContainsKey(numero_poliza) && poliza_contraria != numero_poliza)
                    {
                        Console.Write("Introduzca la matrícula contraria: ");
                        string matricula_contraria = Console.ReadLine();
                        Console.Write("Introduzca el importe: ");
                        int importe = Convert.ToInt32(Console.ReadLine());
                        DatosSiniestro siniestro = new DatosSiniestro(numero, numero_poliza, cia, poliza_contraria, matricula_contraria, importe);
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
                else
                {
                    Console.WriteLine("La poliza no existe.\n");
                }
            }
            else
            {
                Console.WriteLine("El siniestro ya existe.\n");
            }
            break;
        case 2:
            Console.Write("Introduzca el número del siniestro: ");
            int numero_buscar = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_siniestros.ContainsKey(numero_buscar))
            {
                Console.WriteLine("El siniestro no existe.\n");
            }
            else
            {
                diccionario_siniestros.TryGetValue(numero_buscar, out DatosSiniestro siniestro);
                Console.Write("Introduzca fecha de pago del siniestro: ");
                string fecha_pago = Console.ReadLine();
                siniestro.AgregarFechaPago(fecha_pago);
            }
            break;
        case 3:
            Console.Write("Introduzca el número del siniestro: ");
            int numero_buscar2 = Convert.ToInt32(Console.ReadLine());
            if (!diccionario_siniestros.ContainsKey(numero_buscar2))
            {
                Console.WriteLine("El siniestro no existe.\n");
            }
            else
            {
                diccionario_siniestros.TryGetValue(numero_buscar2, out DatosSiniestro siniestro);
                Console.Write("Introduzca fecha de liquidación del siniestro: ");
                string fecha_liquidacion = Console.ReadLine();
                siniestro.AgregarFechaLiquidacion(fecha_liquidacion);
            }
            break;
        case 4:
            break;
        default:
            Console.WriteLine("\n\nLa opción no es válida. Volviendo...\n\n");
            break;
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