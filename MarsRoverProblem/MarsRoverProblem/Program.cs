using MarsRoverProblem.Models;
using MarsRoverProblem.Repositories;
using MarsRoverProblem.Responses;
using MarsRoverProblem.Validations;
using System;
using System.Collections.Generic;

namespace MarsRoverProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = null;

            while (plateau == null)
            {
                Console.Write("Enter upper-right coordinates of the plateau: ");
                string data = Console.ReadLine().Trim();
                var response = PlateauCreationControl.Do(data, out plateau);
                if (!response.IsOk)
                {
                    Console.WriteLine(response.Message);
                    Console.WriteLine(Messages.SpaceBetweenInputs);
                    Console.WriteLine();
                }
            }

            List<Rover> rovers = new List<Rover>();

            for (int i = 1; i <= 2; i++)
            {
                Rover rover = new Rover();
                while (!rover.isReadyForAction)
                {
                    Console.Write("Enter rover's position: ");
                    string data = Console.ReadLine().Trim().ToUpper();
                    var response = RoverDeploymentControl.Do(data, plateau, ref rover);
                    if (!response.IsOk)
                    {
                        Console.WriteLine(response.Message);
                        Console.WriteLine(Messages.SpaceBetweenInputs);
                        Console.WriteLine();
                    }
                }

                string actionData = "";
                ResponseBase actionResponse = new ResponseBase();
                while (!actionResponse.IsOk)
                {
                    Console.Write("Enter series of instructions: ");
                    actionData = Console.ReadLine().Trim().Replace(" ", String.Empty).ToUpper();
                    RoverActionControl.Do(actionData, ref actionResponse);
                    if (!actionResponse.IsOk)
                    {
                        Console.WriteLine(actionResponse.Message);
                        Console.WriteLine();
                    }
                }
                rover.Instructions = actionData;
                rovers.Add(rover);
            }

            for (int i = 0; i < rovers.Count; i++)
            {
                var repo = new RoverRepository();
                var response = new ResponseBase();
                foreach (var action in rovers[i].Instructions)
                {
                    switch (action)
                    {
                        case 'L':
                        case 'R':
                            repo.Rotate(rovers[i], action);
                            break;
                        case 'M':
                            response = repo.Move(rovers[i], plateau);
                            break;
                        default:
                            break;
                    }
                    if (action == 'M' && !response.IsOk)
                    {
                        Console.WriteLine($"{rovers[i].GetName()} {response.Message} It has left the plateau from {rovers[i].GetCoordinates()}.");
                        break;
                    }
                }

                if (response.IsOk)
                {
                    Console.WriteLine($"{rovers[i].GetName()} at {rovers[i].GetCoordinates()} and its direction is {rovers[i].Direction.ToString()}.");
                }
            }



        }
    }
}
