using AplicacionSeguros;
Dictionary<string, Persona> diccionario_personas = new Dictionary<string, Persona>();
Dictionary<string, Empresa> diccionario_empresas = new Dictionary<string, Empresa>();
Dictionary<int, Poliza> diccionario_polizas = new Dictionary<int, Poliza>();

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

bool salir = false;
while (true)
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
            break;
        case 3:
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