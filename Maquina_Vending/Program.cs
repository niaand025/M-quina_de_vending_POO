using System;
using System.Collections.Generic;

namespace Maquina_Vending
{
    class Program
    {
        static List<Usuario> listaUsuarios;
        static void Main(string[] args)
        {
            listaUsuarios = new List<Usuario>();

            //Llamamos a la función para cargar los usuarios desde un archivo. Si devuelve false, es que no hya usuarios
            if (!CargarUsuariosDeArchivo())
            {//Si no hay usuarios, creamos al admin
                Admin admin = new Admin(0, "admin", "Admin", "Admin", "Admin", "admin");
                listaUsuarios.Add(admin);
                admin.ToFile(); //Guardamos el admin en el archivo
            }
            

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1.- Login");
                Console.WriteLine("2.- Registrarse");
                Console.WriteLine("3.- Salir");
                Console.WriteLine("Opción: ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Login();
                            break;

                        case 2:
                            AddUsuario();
                            break;

                        default:
                            Console.WriteLine("Opción no valida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Opción invalida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 3);
        }

        // Solicita usuario y contraseña, comprueba si coincide, y si es así muestra su menú
        public static void Login()
        {
            Console.WriteLine("Nombre de usuario: ");
            string nickname = Console.ReadLine();
            Console.WriteLine("Password: ");
            string pass = Console.ReadLine();
            bool usuarioEncontrado = false;
            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.Login(nickname, pass))
                {
                    usuarioEncontrado = true;
                    usuario.Menu();
                }
            }
            if (!usuarioEncontrado)
            {
                Console.WriteLine("Usuario o contraseña incorrrectos");
            }
        }

        public static void AddUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== Registro de nuevo usuario ===");
            Console.WriteLine("Ingrese un nickname: ");
            string nickname = Console.ReadLine();
            // Verificar si el nickname ya está en uso            
            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.NickName == nickname)
                {
                    Console.WriteLine("El nickname ya está en uso. Intente con otro.");
                    return;
                }
                else
                {
                    Console.WriteLine("Nickname valido");
                }
            }
            // Solicitar otros datos del usuario
            Console.WriteLine("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su primer apellido: ");
            string ape1 = Console.ReadLine();
            Console.WriteLine("Ingrese su segundo apellido: ");
            string ape2 = Console.ReadLine();
            // Generar un ID único para el nuevo usuario
            int idu = listaUsuarios.Count + 1;
            // Solicitar contraseña
            Console.WriteLine("Ingrese su contraseña: ");
            string password = Console.ReadLine();
            // Crear el nuevo cliente y agregarlo a la lista de usuarios
            Cliente nuevoUsuario = new Cliente(idu, nickname, nombre, ape1, ape2, password);
            listaUsuarios.Add(nuevoUsuario);
            nuevoUsuario.ToFile();  //Guardamos el usuario en el archivo

            Console.WriteLine("Usuario registrado con éxito.");
        }
        private static bool CargarUsuariosDeArchivo()
        {
            bool usuariosCargados = false;
            try
            {
                if (File.Exists("usuarios.txt"))
                {
                    StreamReader sr = new StreamReader("usuarios.txt");
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        usuariosCargados = true;
                        string[] datos = linea.Split('|');
                        if (datos[0] == "0") //si el ID es 0, es el admin
                        {
                            Admin a = new Admin(int.Parse(datos[0]), datos[1], datos[2], datos[3], datos[4], datos[5]);
                            listaUsuarios.Add(a);
                        }
                        else
                        {
                            Cliente u = new Cliente(int.Parse(datos[0]), datos[1], datos[2], datos[3], datos[4], datos[5]);
                            listaUsuarios.Add(u);
                        }
                    }
                    sr.Close();
                }
                else
                {
                    //Creamos el archivo vacio con file.create
                    File.Create("usuarios.txt").Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encuentra el archivo de usuarios: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de E/S: " + ex.Message);
            }

            return usuariosCargados;
        }
        
    }
}
