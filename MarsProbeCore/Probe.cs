using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsProbeCore
{
    public class Probe
    {
        public Position InitialPosition { get; private set; }
        public Position CurrentPosition { get; private set; }
        public Grid Grid { get; private set; }
        public char[] CommandList { get; private set; }

        public Probe(Position position, Grid grid, char[] commands)
        {
            InitialPosition = position;
            CurrentPosition = position;
            Grid = grid;
            CommandList = commands;
        }

        public void RunCommands()
        {
            foreach (char command in CommandList )
            {
                if (command == RotationSense.Right || command == RotationSense.Left)
                {
                    Rotate(command);
                }
                else if (command == 'M')
                {
                    Move();
                }
            }
            
        }

        public void Move()
        {
            switch (CurrentPosition.CardinalPoint)
            {
                case char cardinal when (CardinalPoints.North.Equals(cardinal)):
                    if (CurrentPosition.YAxis < Grid.height)
                    {
                        CurrentPosition.YAxis += 1;
                    }                    
                    break;
                case char cardinal when (CardinalPoints.South.Equals(cardinal)):
                    if (CurrentPosition.YAxis > 0)
                    {
                        CurrentPosition.YAxis -= 1;
                    }
                    break;
                case char cardinal when (CardinalPoints.East.Equals(cardinal)):
                    if (CurrentPosition.XAxis < Grid.width)
                    {
                        CurrentPosition.XAxis += 1;
                    }
                    break;
                case char cardinal when (CardinalPoints.West.Equals(cardinal)):
                    if (CurrentPosition.XAxis > 0)
                    {
                        CurrentPosition.XAxis -= 1;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Ponto cardinal inválido ao tentar se mover.");
            }
        }

        public void Rotate(char rotationSense)
        {
            switch (rotationSense)
            {
                case char rotation when (rotation == RotationSense.Right):
                    if (CardinalPoints.North.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East;
                        break;
                    }
                    if (CardinalPoints.East.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South;
                        break;
                    }
                    if (CardinalPoints.South.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West;
                        break;
                    }
                    if (CardinalPoints.West.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North;
                        break;
                    }
                    break;
                case char rotation when (rotation == RotationSense.Left):
                    if (CardinalPoints.North.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.West;
                        break;
                    }
                    if (CardinalPoints.East.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.North;
                        break;
                    }
                    if (CardinalPoints.South.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.East;
                        break;
                    }
                    if (CardinalPoints.West.Equals(CurrentPosition.CardinalPoint))
                    {
                        CurrentPosition.CardinalPoint = CardinalPoints.South;
                        break;
                    }
                    break;                
                default:
                    throw new ArgumentException("Sentido de rotação é inválido. A sonda deve girar L para esquerda (Left) ou R para a direita (Right)");
            }
        }
    }
}
