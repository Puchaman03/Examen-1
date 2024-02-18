using System.Timers;


//Definicion de variables
string Identificacion = "";
int Edad = 0;
int op = 0;
int Pacientes = 0;
int Catalogo = 0;
bool Encontrado = false;
int Max = 10;// tuve que poner un maximo porque sino el programa no funciona
string[] Cedulas = new string[Max];
string[] Nombres = new string[Max];
string[] Tipo_de_Sangre = new string[Max];
string[] Dirrecion = new string[Max];
string[] telefono = new string[Max];
int[] Fecha_de_Nacimiento = new int[Max];
string[] codigoMedicamento = new string[Max];
string[] MedicamentoNombre = new string[Max];
int[] CantidadMedicamento = new int[Max];
string[,] Variedad_de_Medicamentos = new string[Max,3];// aqui guardo los medicamentos de cada paciente
int THEpaciente = 0;
int SellecionMedicamento = 0;
int[] maximoMedicamentos = new int [Max];
int Seleccion_de_Existencias = 0;

while (op < 5)// while para crear el menu
{
    op = Menu(op);// op se basa en la funcion Menu que despliega el menu y permite la digitacion de datos

    switch (op)
    {
        case 1:// Agregar Paciente
            Console.ForegroundColor = ConsoleColor.White;

            // Registro del pacinte
            Console.WriteLine(" Agrege la Cedula del paciente");
            Cedulas[Pacientes] = Console.ReadLine();//Registro de la Cedulas 

            Console.WriteLine(" Agrege el Nombre del paciente");
            Nombres[Pacientes] = Console.ReadLine();// Registro del Nombre

            Console.WriteLine(" Agrege el telefono del paciente");
            telefono[Pacientes] = Console.ReadLine();// Registro del telefono

            Console.WriteLine(" Agrege el tipo de sangre del paciente");
            Tipo_de_Sangre[Pacientes] = Console.ReadLine();// registro del tipo de sangre

            Console.WriteLine(" Agrege la Dirrecion del paciente");
            Dirrecion[Pacientes] = Console.ReadLine();// registro de la dirrecion

            Console.WriteLine(" Agrege el año de Nacimiento del paciente");

            try// el try es para si cuando se registre la edad el usuario pone algo aparte numeros de error
            {
                Edad = int.Parse(Console.ReadLine());

                while (Edad > 2024)// el while es para asegurarse de que el usuario no ponga un año mayor al actual
                {
                    Console.WriteLine("No digite un año, que sobrepase el año actual 2024, Digite el Año de nacimiento del paciente");
                    Edad = int.Parse(Console.ReadLine());


                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Error, Digite el numero de un año, en el registro");
                Edad = int.Parse(Console.ReadLine());
            }
           

            Fecha_de_Nacimiento[Pacientes] = 2024-Edad;// Aqui defino la edad del paciente, por ejemplo el si el usuario dice que el paciente nacio en el año 2000 entonces, significa que el paciente tiene 24 años
            

            Console.WriteLine();
            Pacientes++; // la variable pacientes es para que la cantidad de pacientes se definida por los usuarios
            break;

        case 2://Agregar medicamentos al catalogo
            Console.ForegroundColor = ConsoleColor.Green;
            
            Console.WriteLine($"Digite el codigo del medicamento");
            string NuevoCodigoMedico = Console.ReadLine();// defino la variable de NuevoCodigoMedico para que compare sus datos por los que ya tiene la variable Codigo medicamentos

            bool codigoRepetido = false;// defino el bool codigoRepetido para definir si el codigo si se repitio 

            for (int i = 0; i < Catalogo; i++)
            {
                if (codigoMedicamento[i] == NuevoCodigoMedico)// si el nuevo codigo es igual a unos de los codigos ya registrados hace que codigoRepetido sea true
                {
                    codigoRepetido = true;
                    break;
                }
            }
            if (codigoRepetido)// si codigorepetido es true entonces no permite el ingreso de los demas datos
            {
                Console.WriteLine("Perdon pero no se puede poner el mismo codigo de un medicamento");
            }
            else// en cambio si el codigoRepetido es falso osea si no esta repetido, entonces hace lo siguiente
            {
                codigoMedicamento[Catalogo] = NuevoCodigoMedico;// Aqui guarda el nuevo codigo dentro del arreglo
                
                Console.WriteLine($"Digite el nombre del medicamento, CODIGO: {codigoMedicamento[Catalogo]}");
                MedicamentoNombre[Catalogo] = Console.ReadLine();// Registro del nombre del medicamento

                Console.WriteLine($"Digite la cantidad de {MedicamentoNombre[Catalogo]}");
                CantidadMedicamento[Catalogo] = int.Parse(Console.ReadLine());//registro de la cantidad
                Catalogo++;// similar al case 1 con pacientes, esta variable permite deminir el tamaño del catalogo
            }

            break;

        case 3:// Tratamiento medico a un paciente
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Digite la Cedula del paciente");

            Identificacion = Console.ReadLine();// registro de la cedula que el usuario quiere buscar
            
            for ( int i = 0; i < Pacientes; i++)// tiene que buscar el dentro del tamaño de pacientes
            {
                if (Identificacion.Equals(Cedulas[i]))// si identificacion encuentra un coencidencia hace lo siguiente
                {
                    THEpaciente = i;// variable para guardar la posicion del paciente
                    Encontrado = true;// significa que la indentificacion ha encontrado un dato igualitario
                    Console.WriteLine("""
Cedula encontrada 
""");
                    Console.WriteLine($"Paciente: {Nombres[i]}");// para mostrar el nombre del paciente
                    try
                    {                        
                        Console.WriteLine("Catalogo de Medicamentos disponibles");
                        
                        //Aqui se mostrara el catalogo completo
                        for (int j = 0; j < Catalogo; j++)
                        {
                            Console.WriteLine($"{j + 1} - Codigo: {codigoMedicamento[j]} -Nombre de Medicamento: {MedicamentoNombre[j]}");
                        }

                        //Aqui se selecciona una de las opciones del catalogo
                        Console.WriteLine(" Seleccione un medicamento");
                        SellecionMedicamento = int.Parse(Console.ReadLine());// escribi mal seleccion pero cuando me di cuenta ya era muy tarde y no queria que tener todas la instacias solo por una letra de mas

                        while(SellecionMedicamento > Catalogo || SellecionMedicamento < 1) // si seleccion es mayor al numero de medicamentos disponible o menor a 0 entonces se hace lo siguiente
                        {
                            //basicamente repeti la muestra de catalogo y seleccion hasta que sea valida
                            Console.WriteLine(" Error, no selecciono una de las opciones disponibles ");
                            Console.WriteLine("Catalogo de Medicamentos disponibles");
                            for (int j = 0; j < Catalogo; j++)
                            {
                                Console.WriteLine($"{j + 1} - Codigo: {codigoMedicamento[j]} -Nombre de Medicamento {MedicamentoNombre[j]}");
                            }
                            Console.WriteLine(" Seleccione un medicamento");
                            SellecionMedicamento = int.Parse(Console.ReadLine());
                        }

                        // la idea que es que maximoMedicamentos en la posicion de paciente es superior a 3 significa que el paciente ya posee mas de 3 medicamentos 
                        if (maximoMedicamentos[THEpaciente] > 3)
                        {
                            Console.WriteLine($"El paciente {Nombres[i]} ya posee mas de 3 medicamentos prescritos");
                            break;
                        }

                        // Aqui muestro la existencias de medicamentos en el catalogo y hago que usuario digite cuantos de estos va tomar

                        try
                        {
                            Console.WriteLine($"El medicamento {MedicamentoNombre[SellecionMedicamento - 1]} posee en existencias {CantidadMedicamento[SellecionMedicamento - 1]}, cuantas desea");// el -1 es por como funcionan los arreglos que inician en 0
                            Seleccion_de_Existencias = int.Parse(Console.ReadLine());

                            // esto es por el usuario solicita una cantidad mayor de la existente
                            if (Seleccion_de_Existencias > CantidadMedicamento[SellecionMedicamento - 1] || Seleccion_de_Existencias < 0)
                            {
                                Console.WriteLine("Perdon pero, la cantidad solicitada, no esta disponible");
                                break;

                            }
                            else// si no hace lo siguiente
                            {
                                Console.WriteLine("Datos Guardados con exito");

                                Variedad_de_Medicamentos[THEpaciente, maximoMedicamentos[THEpaciente]] = codigoMedicamento[SellecionMedicamento - 1];
                                
                                //Aqui en el arreglo maximoMedicamentos lo que hago es lo siguiente: digamos que el paciente que queremos dar tratamiento
                                // Esta dentro del arreglo cedulas en la posicion 2, y la variable THEpaciente se encarga de guardar esa posicion por lo que ahora esa variable es 2
                                // lo que lo que hago aqui es que dentro del arreglo maximoMedicamentos hago que en la posicion[2] vaya sumando +1
                                // Lo que hace que el si el usuario quiera poner mas de 3 medicamentos dentro del arreglo, el if de antes dectectara que el arreglo maximoMedicamentos posicion 2 tiene un valor de 3 no permita guardar el nuevo medicamento
                                
                                maximoMedicamentos[THEpaciente]++;
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("ERROR, en el registro de tratamientos");//  por si el usuario pone algo que no sea numeros
                            break;
                        }
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error en digitacion de la cedula");
                        SellecionMedicamento = 0;
                    }
                    break;
                    
                }
                
            }
            if (!Encontrado)// entonces no se hace nada
            {
                Console.WriteLine($"No se encontro la Cedula {Identificacion}");
                break;
            }
            
            break;

        case 4://Consultas 

            Console.WriteLine($"Cantidad de pacientes registrados {Pacientes}");//simplemente muestro el valor de pacientes en el momento 
            Console.WriteLine();

            // definicion de la variables para las edades
            int edad_10 = 0;
            int edad_30 = 0;
            int edad_50 = 0;
            int edad_50Mayor = 0;

            Console.WriteLine("""
Reporte de Catalogo
""");
            
            // muestro los codigos y nombres de los medicamentos
            for (int i = 0;i < Catalogo; i++)
            {
                Console.WriteLine($"CODIGO: {codigoMedicamento[i]} - NOMBRE: {MedicamentoNombre[i]}");
            }


            //Aqui hago que i recora la cantidad de pacientes 
            for (int i = 0; i < Pacientes; i++) 
            {
                // Aqui si fecha de nacimiento concuerda con algunos de los if la respectiva variable suma +1
                if (Fecha_de_Nacimiento[i] >= 0 && Fecha_de_Nacimiento[i] <= 10)
                {
                    edad_10 += 1;
                }
                if (Fecha_de_Nacimiento[i] >= 11 && Fecha_de_Nacimiento[i] <= 30)
                {
                    edad_30 += 1;
                }
                if (Fecha_de_Nacimiento[i] >= 31 && Fecha_de_Nacimiento[i] <= 50)
                {
                    edad_50 += 1;
                }
                if (Fecha_de_Nacimiento[i] > 50)
                {
                    edad_50Mayor += 1;
                }

            }
            Console.WriteLine();


            //muestro el numero de pacientes con sus edades 
            Console.WriteLine(""""
                Reporte de edades de Pacientes: 
                """");
            Console.WriteLine($"Numero de pacientes de 0 - 10 años: {edad_10}");
            Console.WriteLine($"Numero de pacientes de 11 - 30 años: {edad_30}");
            Console.WriteLine($"Numero de pacientes de 31 - 50 años: {edad_50}");
            Console.WriteLine($"Numero de pacientes de mayores a los 51 años: {edad_50Mayor}");
            Console.WriteLine();
            Console.WriteLine(""""
Reporte de Pacientes
"""");
    
            //Muestro los datos del paciente
            for (int i = 0;i < Pacientes; i++)
            {
                Console.WriteLine($"Nombres {Nombres[i]} - Cedula: {Cedulas[i]} - Tipo de Sangre: {Tipo_de_Sangre[i]} - Direccion: {Dirrecion[i]}- Telefono:{telefono[i]}");
                Console.WriteLine("Medicamentos Prescritos");

                // con este for muestro los datos guardados en la matriz
                for (int j = 0;j < 3; j++)
                {
                    Console.WriteLine(Variedad_de_Medicamentos[i,j]);

                }
                Console.WriteLine();
                
            }

            break;
    }   

}

Console.WriteLine("Gracias por usar nuestro servicio");


static int Menu(int op) // Esta una funcion, que crea el menu
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;// esto es para darle color nada mas 

    Console.WriteLine("""
        **********Bienvenido al Sistema de Gestion de Pacientes y Consultas Medicas**************

     -1 Agregar Paciente

     -2 Agregar Medicamento al catalogo

     -3 Asignar Tratamiento Medico a un paciente

     -4 Consultas

     -5 o > Salir

     """);

    try//pongo try para que si el usuario pone algo que no sea un numero, o un numero negativo para evitando dar error 
    {
        op = int.Parse(Console.ReadLine()); // Aqui pido el operador

        if (op <= 0)// por si el usuario pone numeros negativos
        {
            Console.WriteLine(@"
Porfavor astengase de poner numeros negativos o nulos
");
            op = 0;

        }
    }
    catch (FormatException)// por si el usurio pone algo que no sea numeros. el formatExceotion captura elementos que no sea del mismo tipo, por ejemplo op es init pero si se pone una letra cuando se solicita seria string por lo que el catch los dectecta 
    {
        Console.WriteLine("Digite una opcion válida.");
        Console.WriteLine();
        op = 0; // Reiniciar op si se produce un error de formato
    }

    return op;
}