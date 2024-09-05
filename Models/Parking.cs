using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parking_system.Models
{
    public class Parking
    {

        public decimal InitialPrice {set; get;}
        public decimal PricePerHour { set; get;}
        //public List<string> VehicleList {set; get;}
        public List <string> VehicleList = new List<string>();


        public void RegisterVehicle() {
            Console.WriteLine("Digite a placa do veículo a ser registrado: ");
            string vehiclePlate = Console.ReadLine();
            this.VehicleList.Add(vehiclePlate);
            Console.WriteLine("Digite uma tecla para retornar.");
            Console.ReadKey();
            this.PrincipalMenu();
        }

        public void RemoveVehicle() {
            Console.WriteLine("Digite a placa do veículo a ser removido: ");
            string plateToSearch = Console.ReadLine();
            string findPlate =  this.VehicleList.Find(plate => plate == plateToSearch);
            int hoursParked;
            if(findPlate == "") {
                Console.WriteLine("Não há veículo cadastrado com esta placa.");
            } else {
                Console.WriteLine("Digite a quantidade de horas que o veículo ficou estacionado: ");
                hoursParked = Convert.ToInt32(Console.ReadLine());
                decimal price = this.CalcPrice(hoursParked);
                this.VehicleList.Remove(findPlate);
                Console.WriteLine($"O veículo {findPlate} foi removido e o preço total foi de R${price}");
                Console.WriteLine("Digite uma tecla para retornar.");
                Console.ReadKey();
                this.PrincipalMenu();
            }
        }

        public void ListVehicles() {
            Console.WriteLine("Os carros presentes no estacionamento são: ");
            foreach (string plate in this.VehicleList)
            {
                Console.WriteLine(plate);
            }
            Console.WriteLine("Digite uma tecla para retornar.");
            Console.ReadKey();
            this.PrincipalMenu();
        }

        private decimal CalcPrice(int time) {
            decimal totalPrice = this.PricePerHour * time + InitialPrice;
            return totalPrice;
        }

        public void WelcomeScreen() {
            Console.WriteLine("Seja bem-vindo ao Sistema de Estacionamento!");
            Console.WriteLine("Digite o preço inicial: ");
            this.InitialPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Agora digite o preço por hora: ");
            this.PricePerHour = Convert.ToDecimal(Console.ReadLine());
            this.PrincipalMenu();
        }

        public void PrincipalMenu() {
            Console.WriteLine("Digite sua opção: ");
            Console.WriteLine("1 - Cadastrar veículo ");
            Console.WriteLine("2 - Remover veículo ");
            Console.WriteLine("3 - Listar veículos ");
            Console.WriteLine("4 - Encerrar ");

            int chooseOption = Convert.ToInt32(Console.ReadLine());

            switch(chooseOption) {
                case 1:
                    RegisterVehicle();
                    break;
                case 2:
                    RemoveVehicle();
                    break;
                case 3:
                    ListVehicles();
                    break;
                case 4:
                    WelcomeScreen();
                    break;
            }
        }
    }
}