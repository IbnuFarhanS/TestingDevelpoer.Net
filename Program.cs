using System;
using System.Collections.Generic;

namespace Developer_.net_
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowInitialInformation();

            // Inisialisasi variabel parkingLot dengan nilai null
            ParkingLot parkingLot = null;

            while (true)
            {
                // Membaca input dari pengguna
                string input = Console.ReadLine();
                // Memisahkan input menjadi array menggunakan delimiter " : "
                string[] command = input.Split(" : ");

                // Melakukan operasi berdasarkan perintah yang diberikan
                switch (command[0])
                {
                    case "create_lot":
                        // Membuat dan menginisialisasi objek ParkingLot dengan jumlah slot yang diberikan
                        int slots;
                        if (int.TryParse(command[1], out slots))
                        {
                            if (slots <= 0)
                            {
                                Console.WriteLine("Invalid slot number. Please enter a positive integer value.");
                                continue;
                            }

                            parkingLot = new ParkingLot(slots);
                            Console.WriteLine("Created a parking lot with " + slots + " slots");
                            Console.WriteLine();
                            Console.WriteLine("Input Your Command !!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number. Please enter a valid integer value.");
                        }
                        break;
                    case "park":
                        // Mem-parkirkan kendaraan ke dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 4)
                        {
                            Console.WriteLine("Invalid park command format. Please specify the registration number, color, and vehicle type.");
                            continue;
                        }

                        string registrationNo = command[1];
                        string color = command[2];
                        string type = command[3];
                        parkingLot.ParkVehicle(registrationNo, color, type);
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "leave":
                        // Membuang slot parkir dan membebaskan kendaraan
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 2)
                        {
                            Console.WriteLine("Invalid leave command format. Please specify the slot number.");
                            continue;
                        }

                        int slotNumber;
                        if (int.TryParse(command[1], out slotNumber))
                        {
                            // Memeriksa apakah slot parkir dengan nomor yang diberikan berisi kendaraan
                            if (parkingLot.GetVehicleBySlotNumber(slotNumber, out Vehicle vehicle))
                            {
                                decimal parkingFee = parkingLot.CalculateParkingFee(vehicle.RegistrationNo);
                                parkingLot.Leave(slotNumber);
                                Console.WriteLine("Vehicle with registration number " + vehicle.RegistrationNo + " has left the parking lot. Parking fee: " + parkingFee + "/hour");
                            }
                            else
                            {
                                Console.WriteLine("Slot number " + slotNumber + " is already empty");
                            }

                            Console.WriteLine();
                            Console.WriteLine("Input Your Command !!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number. Please enter a valid integer value.");
                        }
                        break;
                    case "status":
                        // Menampilkan status parkir di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        parkingLot.Status();
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "type":
                        // Menampilkan jumlah kendaraan berdasarkan jenisnya di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 2)
                        {
                            Console.WriteLine("Invalid type command format. Please specify the vehicle type.");
                            continue;
                        }

                        parkingLot.TypeOfVehicles(command[1]);
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "odd_plate":
                        // Menampilkan nomor registrasi kendaraan dengan plat ganjil di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        parkingLot.VehiclesWithOddPlate();
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "even_plate":
                        // Menampilkan nomor registrasi kendaraan dengan plat genap di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        parkingLot.VehiclesWithEvenPlate();
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "plate_with_colour":
                        // Menampilkan nomor registrasi kendaraan dengan warna tertentu di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 2)
                        {
                            Console.WriteLine("Invalid plate_with_colour command format. Please specify the color.");
                            continue;
                        }

                        parkingLot.PlateWithColour(command[1]);
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "slot_with_colour":
                        // Menampilkan nomor slot kendaraan dengan warna tertentu di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 2)
                        {
                            Console.WriteLine("Invalid slot_with_colour command format. Please specify the color.");
                            continue;
                        }

                        parkingLot.SlotWithColour(command[1]);
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "slot_with_plate":
                        // Menampilkan nomor slot kendaraan dengan nomor registrasi tertentu di dalam parkingLot
                        if (parkingLot == null)
                        {
                            Console.WriteLine("Please create a parking lot first.");
                            continue;
                        }

                        if (command.Length < 2)
                        {
                            Console.WriteLine("Invalid slot_with_plate command format. Please specify the registration number.");
                            continue;
                        }

                        parkingLot.SlotWithNumberPlate(command[1]);
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                    case "exit":
                        // Keluar dari program
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        Console.WriteLine();
                        Console.WriteLine("Input Your Command !!");
                        break;
                }
            }
        }

        static void ShowInitialInformation()
        {
            Console.WriteLine("====== Welcome to the Parking Program ======");
            Console.WriteLine("Berikut adalah command yang dapat digunakan:");
            Console.WriteLine("1. Ketikkan command create_lot : jumlah lot Ex = <create_lot : 5>");
            Console.WriteLine("2. Ketikkan command park : kendaraan Ex = <park : ABC1234 : Merah : Mobil>");
            Console.WriteLine("3. Ketikkan command leave : no lot Ex = <leave : 3>");
            Console.WriteLine("4. Ketikkan command <status>");
            Console.WriteLine("5. Ketikkan command type : kendaraan Ex = <type : Motor>");
            Console.WriteLine("6. Ketikkan command <odd_plate> untuk plat ganjil");
            Console.WriteLine("7. Ketikkan command <even_plate> untuk plat genap");
            Console.WriteLine("8. Ketikkan command <plate_with_colour : warna> menampilkan plate");
            Console.WriteLine("9. Ketikkan command <slot_with_colour : warna> menampilkan slot parkir");
            Console.WriteLine("10. Ketikkan command <slot_with_plate : No Plat Kendaraan> menampilkan slot parkir");
            Console.WriteLine("11. Ketikkan command <exit> untuk keluar");
            Console.WriteLine("=============================================");
            Console.WriteLine();
            Console.WriteLine("Input Your Command !!");
        }
    }

    class ParkingLot
    {
        private int totalSlots;
        private Dictionary<int, Vehicle> parkingSlots;

        public Dictionary<int, Vehicle> ParkingSlots
        {
            get { return parkingSlots; }
        }

        public ParkingLot(int slots)
        {
            // Menginisialisasi totalSlots dengan jumlah slot yang diberikan
            totalSlots = slots;
            // Menginisialisasi parkingSlots dengan sebuah Dictionary yang akan digunakan untuk menyimpan kendaraan yang diparkir di setiap slot
            parkingSlots = new Dictionary<int, Vehicle>();
        }

        public void ParkVehicle(string registrationNo, string color, string type)
        {
            // Memeriksa apakah parkingSlots sudah penuh
            if (parkingSlots.Count >= totalSlots)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            Vehicle vehicle;
            // Membuat objek kendaraan baru berdasarkan jenis yang diberikan
            if (type.ToLower() == "mobil")
            {
                vehicle = new Car(registrationNo, color);
            }
            else if (type.ToLower() == "motor")
            {
                vehicle = new Motorbike(registrationNo, color);
            }
            else
            {
                Console.WriteLine("Invalid vehicle type");
                return;
            }

            vehicle.EntryTime = DateTime.Now;

            // Mencari slot parkir yang tersedia untuk mem-parkirkan kendaraan
            for (int i = 1; i <= totalSlots; i++)
            {
                if (!parkingSlots.ContainsKey(i))
                {
                    // Menambahkan kendaraan ke dalam slot parkir yang tersedia
                    parkingSlots[i] = vehicle;
                    Console.WriteLine("Allocated slot number: " + i);
                    return;
                }
            }
        }

        public void Leave(int slotNumber)
        {
            // Memeriksa apakah nomor slot yang diberikan valid
            if (slotNumber < 1 || slotNumber > totalSlots)
            {
                Console.WriteLine("Invalid slot number");
                return;
            }

            // Memeriksa apakah slot parkir dengan nomor yang diberikan berisi kendaraan
            if (parkingSlots.ContainsKey(slotNumber))
            {
                // Menghapus kendaraan dari slot parkir yang diberikan
                parkingSlots.Remove(slotNumber);
                Console.WriteLine("Slot number " + slotNumber + " is free");
            }
            else
            {
                Console.WriteLine("Slot number " + slotNumber + " is already empty");
            }
        }

        public void Status()
        {
            // Memeriksa apakah tidak ada kendaraan yang terparkir di dalam parkingLot
            if (parkingSlots.Count == 0)
            {
                Console.WriteLine("Parking lot is empty");
                return;
            }

            // Menampilkan status parkir dari setiap slot di dalam parkingLot
            Console.WriteLine("Slot\tNo.\t\tType\t\tRegistration No Colour");
            foreach (var slot in parkingSlots)
            {
                Console.WriteLine(slot.Key + "\t" + slot.Value.RegistrationNo + "\t" + slot.Value.Type + "\t" + slot.Value.Color);
            }

            // Menampilkan jumlah lot yang masih belum diisi kendaraan
            int emptySlots = totalSlots - parkingSlots.Count;
            Console.WriteLine("Empty slots: " + emptySlots);

            // Menampilkan jumlah lot yang tersedia
            int availableSlots = totalSlots - emptySlots;
            Console.WriteLine("Available slots: " + availableSlots);
        }


        public void TypeOfVehicles(string type)
        {
            int count = 0;
            // Menghitung jumlah kendaraan berdasarkan jenisnya di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (slot.Value.Type.ToLower() == type.ToLower())
                {
                    count++;
                }
            }
            Console.WriteLine("Total " + count + " " + type + "(s)");
        }

        public void VehiclesWithOddPlate()
        {
            List<string> registrationNumbers = new List<string>();
            int count = 0; // Menambahkan variabel untuk menghitung jumlah kendaraan ganjil

            // Mengumpulkan nomor registrasi kendaraan dengan plat ganjil di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (IsOddPlate(slot.Value.RegistrationNo))
                {
                    registrationNumbers.Add(slot.Value.RegistrationNo);
                    count++; // Menghitung kendaraan dengan plat ganjil
                }
            }

            if (registrationNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", registrationNumbers));
            }
            else
            {
                Console.WriteLine("No vehicles with odd plate numbers found");
            }

            // Menampilkan jumlah kendaraan ganjil
            Console.WriteLine("Total vehicles with odd plate numbers: " + count);
        }

        public void VehiclesWithEvenPlate()
        {
            List<string> registrationNumbers = new List<string>();
            int count = 0; // Menambahkan variabel untuk menghitung jumlah kendaraan genap

            // Mengumpulkan nomor registrasi kendaraan dengan plat genap di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (!IsOddPlate(slot.Value.RegistrationNo))
                {
                    registrationNumbers.Add(slot.Value.RegistrationNo);
                    count++; // Menghitung kendaraan dengan plat genap
                }
            }

            if (registrationNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", registrationNumbers));
            }
            else
            {
                Console.WriteLine("No vehicles with even plate numbers found");
            }

            // Menampilkan jumlah kendaraan genap
            Console.WriteLine("Total vehicles with even plate numbers: " + count);
        }

        public void PlateWithColour(string color)
        {
            List<string> registrationNumbers = new List<string>();
            int count = 0; // Menambahkan variabel untuk menghitung jumlah kendaraan berdasarkan warna

            // Mengumpulkan nomor registrasi kendaraan dengan warna tertentu di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (slot.Value.Color.ToLower() == color.ToLower())
                {
                    registrationNumbers.Add(slot.Value.RegistrationNo);
                    count++; // Menghitung kendaraan berdasarkan warna
                }
            }
            if (registrationNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", registrationNumbers));
            }
            else
            {
                Console.WriteLine("No vehicles with the specified color found");
            }

            // Menampilkan jumlah kendaraan berdasarkan warna
            Console.WriteLine("Total vehicles with colour " + color + " : " + count);
        }

        public void SlotWithColour(string color)
        {
            List<string> slotNumbers = new List<string>();
            int count = 0; // Menambahkan variabel untuk menghitung jumlah slot berdasarkan warna

            // Mengumpulkan nomor slot kendaraan dengan warna tertentu di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (slot.Value.Color.ToLower() == color.ToLower())
                {
                    slotNumbers.Add(slot.Key.ToString());
                    count++; // Menghitung slot berdasarkan warna
                }
            }

            if (slotNumbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", slotNumbers));
            }
            else
            {
                Console.WriteLine("No vehicles with the specified color found");
            }

            // Menampilkan jumlah slot berdasarkan warna
            Console.WriteLine("Total vehicles with colour " + color + " : " + count);
        }

        public void SlotWithNumberPlate(string registrationNo)
        {
            // Mencari nomor slot kendaraan dengan nomor registrasi tertentu di dalam parkingLot
            foreach (var slot in parkingSlots)
            {
                if (slot.Value.RegistrationNo.ToLower() == registrationNo.ToLower())
                {
                    Console.WriteLine("Vehicle with registration number " + registrationNo + " is parked at slot number " + slot.Key);
                    return;
                }
            }
            Console.WriteLine("Vehicle with registration number " + registrationNo + " is not found");
        }

        private bool IsOddPlate(string registrationNo)
        {
            // Memeriksa apakah nomor registrasi kendaraan memiliki digit terakhir yang ganjil
            char lastChar = registrationNo[registrationNo.Length - 1];
            return char.IsNumber(lastChar) && (int)char.GetNumericValue(lastChar) % 2 != 0;
        }

        public bool GetVehicleBySlotNumber(int slotNumber, out Vehicle vehicle)
        {
            return parkingSlots.TryGetValue(slotNumber, out vehicle);
        }

        public decimal CalculateParkingFee(string registrationNo)
        {
            // Mencari kendaraan dengan nomor registrasi tertentu
            foreach (var slot in parkingSlots)
            {
                if (slot.Value.RegistrationNo.ToLower() == registrationNo.ToLower())
                {
                    // Menghitung durasi parkir dalam jam
                    TimeSpan duration = DateTime.Now - slot.Value.EntryTime;
                    int hours = (int)Math.Ceiling(duration.TotalHours);

                    // Menghitung biaya parkir berdasarkan durasi
                    decimal fee = hours * 10000; // Harga parkir per jam adalah 10
                    return fee;
                }
            }

            // Kendaraan dengan nomor registrasi yang diberikan tidak ditemukan
            return -1;
        }
    }

    abstract class Vehicle
    {
        public string RegistrationNo { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public DateTime EntryTime { get; set; }

        public Vehicle(string registrationNo, string color)
        {
            // Menginisialisasi nomor registrasi dan warna kendaraan
            RegistrationNo = registrationNo;
            Color = color;
        }
    }

    class Car : Vehicle
    {
        public Car(string registrationNo, string color) : base(registrationNo, color)
        {
            Type = "Mobil";
        }
    }

    class Motorbike : Vehicle
    {
        public Motorbike(string registrationNo, string color) : base(registrationNo, color)
        {
            Type = "Motor";
        }
    }
}