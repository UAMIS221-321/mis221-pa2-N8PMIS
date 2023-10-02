//Nate Pedigo PA 2 
//CWID:12133119

//Untested but Confident
//Returns string selection and formats output, doesn't run Compass() or ParkFees()

using System.Runtime.CompilerServices;
using System;
using System.Globalization;

const double ADMISSION =  12.00;

//Functions
    string MainMenu(){
        Console.Clear();
        Console.WriteLine("Welcome to the ASPS Companion Service!");

        if (File.Exists("trees.txt")) {
            
            string str = File.ReadAllText("trees.txt");
            Console.WriteLine(str);
        }
        

        Console.WriteLine("\nSelect A Service to Continue:\n\n\t\t- Type \"C\" for the Compass Feature\n\t\t- Type \"P\" for the Park Fees feature\n\t\t- Type \"E\" to exit the program\n\n\nSelection: ");
        string input = Console.ReadLine();

        while(input!="C"&&input!="c"&&input!="P"&&input!="p"&&input!="E"&&input!="e"){
            Console.Clear();
            Console.WriteLine("Invalid Selection, please choose from the options provided.\n");
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Welcome to the ASPS Companion Service!\n\nSelect A Service to Continue:\n\n- Type \"C\" for the Compass Feature\n- Type \"P\" for the Park Fees feature\n- Type \"E\" to exit the program\n\n\nSelection: ");

            input=Console.ReadLine();
        }
        Console.Clear();

        return input;
    }

    //COMPLETE
    void Compass(){
        Console.Clear();
        Console.WriteLine("Welcome to the ASPS Compass Feature!\n\nThis feature is designed to help you navigate the various trails and passages found in ASPS Parks!\n");
        Console.WriteLine("-------------------------------------------");

        //Variable Declaration for Continue Prompt and User Input checking
        bool cont = true; 
        string inUser = "";
        
        while(cont){
            int right = 0;
            int left = 0;

            //Collecting Valid Data on Right Turns
            Console.WriteLine("Enter the number of Right Turns taken: ");
            inUser = Console.ReadLine();
            bool valid = inUser.All(char.IsDigit);

            while(!valid || int.Parse(inUser)<0){
                Console.WriteLine("Invalid input. Enter the number of Right Turns taken: " );
                inUser = Console.ReadLine();
                valid = inUser.All(char.IsDigit);
            }
        
            //Right Assignment
            right = int.Parse(inUser);


            //Clearing variables and printing a space
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            inUser = "";
            valid = false;

            //Collecting Valid Data on Left Turns
            Console.WriteLine("Enter the number of Left Turns taken: ");
            inUser = Console.ReadLine();
            valid = inUser.All(char.IsDigit);

            while(!valid || int.Parse(inUser)<0){
                Console.WriteLine("Invalid input. Enter the number of Left Turns taken: " );
                inUser = Console.ReadLine();
                valid = inUser.All(char.IsDigit);
            }
            
            //Left Assignment
            left = int.Parse(inUser);

            //Eliminating Counterparts
            int difference = right - left; 
            int modTurns = 0;

            //Handling negative difference case
            if(difference<0){
                modTurns = (difference * -1) % 4;
            }
            else{
                modTurns = difference % 4;
            }

            //Dummy value
            char dirrection = 'D';


            //IF NO TURNS OR MULTIPLE of 4, FACING NORTH
            if(difference==0 || modTurns==0){
                dirrection = 'N';
            }

            //MORE RIGHT TURNS THAN LEFT, GO CLOCKWISE
            else if(difference > 0){
                if(modTurns==1){
                    dirrection='E';
                }
                else if(modTurns==2){
                    dirrection='S';
                }   
                else if(modTurns==3){
                    
                    dirrection='W';
                }
            }

            //MORE LEFT TURNS THAN RIGHT, GO CCW
            else if(difference < 0){
                if(modTurns==1){
                    dirrection='W';
                }
                else if(modTurns==2){
                    dirrection='S';
                }
                else if(modTurns==3){
                    dirrection='E';
                }
            }

            //Fake Loading Screen
            Console.Clear();
            Console.WriteLine("Welcome to the ASPS Compass Feature!\n\nThis feature is designed to help you navigate the various trails and passages found in ASPS Parks!\n");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.Write("Calculating Current Direction");

            for(int i=0;i<6;i++){
                Console.Write(".");
                Thread.Sleep(750);
            }

            Console.Clear();
            Console.WriteLine("Welcome to the ASPS Compass Feature!\n\nThis feature is designed to help you navigate the various trails and passages found in ASPS Parks!\n");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            //Display Output
            Console.WriteLine("\nYou are Currently Facing: " + dirrection);
            Thread.Sleep(5000);
            Console.Clear();
    
            //Continue Prompt
            string input = "-";
            Console.WriteLine("Would you like to continue using the compass? (Y/N): ");
            input = Console.ReadLine();

            while(input!="y"&&input!="Y"&&input!="n"&&input!="N"){
                Console.Clear();
                Console.WriteLine("Invalid input. Would you like to continue using the compass? (Y/N): ");
                input = Console.ReadLine();
            }

            if(input=="Y" || input=="y"){
                cont = true;
            }
            else if(input == "N" || input == "n"){
                cont = false;
            }
        }
    }

    //COMPLETE, Missing extra data checks in Additional Payment section
    void ParkFees(){

        //Variables and Constants
        double finalFee = 0.00;
        const double FED_TAX = 1.09;
        const double ADMISSION = 12.00;
        bool rv = false;
        bool highCap = false;
        int numChildren = 0;
        int numAdults = 0;

        //Formatting
        Console.Clear();
        Console.WriteLine("Welcome to the ASPS Park Fee Companion!");
        Console.WriteLine("-------------------------------------------");

        //RV HANDLER
            Console.WriteLine("Are you currently visiting an APSPS in a Mobile Home or RV Trailer style vehicle?\n(Y/N): ");
            string input = Console.ReadLine();
            while(input!="y"&&input!="Y"&&input!="n"&&input!="N"){
                Console.Clear();
                Console.WriteLine("Invalid input. Are you visiting today in a Mobile Home or RV Trailer? (Y/N): ");
                input = Console.ReadLine();
                }

            if(input=="y" || input == "Y"){
                rv = true;
            }


        //Quantity Adults
            //Formatting + Prompt
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Please enter how many Adults ( 12+) are visiting: ");

            //Data checker
            input = Console.ReadLine();
            bool valid = input.All(char.IsDigit);

            //Handling bad input
            while(!valid || int.Parse(input)<0){
                Console.WriteLine("Invalid input. Enter the number of adults: " );
                input = Console.ReadLine();
                valid = input.All(char.IsDigit);
            }
            
            //Number Adults Assignment
            numAdults = int.Parse(input);

            //Variable clearing
            input="";
            valid = false; 

        //Quantity Children
            //Formatting + Prompt
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Please enter how many Children (<12) are visiting: ");

            //Data checker
            input = Console.ReadLine();
            valid = input.All(char.IsDigit);

            //Handling Bad Input
            while(!valid || int.Parse(input)<0){
                Console.WriteLine("Invalid input. Enter the number of children: " );
                input = Console.ReadLine();
                valid = input.All(char.IsDigit);
            }

            //Number Children Assignment
            numChildren=int.Parse(input);

        //High Capacity Test
        if((numChildren + numAdults)>=6){
            highCap=true;
        }

        //Price Calculation
        finalFee += (((numAdults * ADMISSION) + ((numChildren * ADMISSION) *0.8 )));

        if(rv){
            finalFee+=20.00;
        }
        else{
            finalFee+=10.00;
        }

        //Federal Tax
        finalFee *= FED_TAX;

        //High Capacity Tax after all other expenses
        if(highCap){
            finalFee+= 5.00;
        }


        
        Console.Clear();
        Console.WriteLine("Welcome to the ASPS Park Fee Companion!");
        Console.WriteLine("-------------------------------------------");
        finalFee = Math.Round(finalFee,2);
        Console.WriteLine("The Total Cost for your visit today is: $" + finalFee + "\n" );
        Console.WriteLine("Please Enter the Amount Paid: ");

        double payed = double.Parse(Console.ReadLine());
        
        finalFee -= payed;

        while(finalFee>0){
            Console.WriteLine("Remaining Balance: $" + finalFee);
            Console.Write("Enter Additonal Payment: $");
            payed = double.Parse(Console.ReadLine());
            finalFee -= payed;
        }


        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("ASPS Park Fee Companion");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Thank you for choosing ASPS, please come again!");
        Thread.Sleep(5000);
    }

//Main
    string userIn = "-1";

    userIn = MainMenu();

    while(userIn!="E"&&userIn!="e"){
        if(userIn == "C" || userIn == "c"){
            Compass();
        }
        else if(userIn == "P" || userIn == "p"){
            ParkFees();
        }
        else{
            Console.WriteLine("ERROR!");
            break;
        }

        userIn=MainMenu();
    }

    Console.Clear();
    Console.WriteLine("Have a nice day and thank you for using the ASPS Companion Application!");
    Thread.Sleep(5000);
    Console.Clear();