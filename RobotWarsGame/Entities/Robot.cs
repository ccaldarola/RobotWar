using RobotWarsGame.Exceptions;
using System;

namespace RobotWarsGame.Entities
{
    public class Robot
    {
        private readonly int xPositionConfig = 0;
        private readonly int yPositionConfig = 1;
        private readonly int directionPositionConfig = 2;
        private Position CurrentPosition { get; set; }
        private Arena Arena { get; set; }

        public void Play(string moves)
        {
            foreach (char move in moves.ToUpper())
            {
                Move(GetDirectionFromChar(move));
            }
        }

        public Robot(string configuration, Arena arena)
        {
            string[] configurations = configuration.ToUpper().Split(' ');
            if (configurations.Length < 3)
            {
                throw new InvalidPositionException($"The position {configuration} is invalid. Should be x y d");
            }

            int xInitialPos;
            int yInitialPos;
            char initialDirection = Convert.ToChar(configurations[directionPositionConfig]);

            if (!int.TryParse(configurations[xPositionConfig], out xInitialPos))
            {
                throw new InvalidPositionException($"The position {configuration} is invalid. Should be x y d");
            }
            if (!int.TryParse(configurations[yPositionConfig], out yInitialPos))
            {
                throw new InvalidPositionException($"The position {configuration} is invalid. Should be x y d");
            }

            Arena = arena;

            CurrentPosition = new Position()
            {
                FacingCardinalCompassPoint = GetCardinalCompassPointFromChar(initialDirection),
                XPosition = xInitialPos,
                YPosition = yInitialPos
            };

            ValidateCurrentPosition();

        }

        public Position GetFinalPosition()
        {
            return CurrentPosition;
        }

        private void Move(DirectionToMove newDirection)
        {
            switch (newDirection)
            {
                case DirectionToMove.Left:
                    RotateLeft();
                    break;
                case DirectionToMove.Move:
                    MoveForward();
                    break;
                case DirectionToMove.Right:
                    RotateRight();
                    break;
                default:
                    throw new UnrecognisedDirectionMoveException(
                        $"The instruction {newDirection} is not valid. Should be R L or M");
                    break;
            }
        }

        private void MoveForward()
        {
            switch (CurrentPosition.FacingCardinalCompassPoint)
            {
                case CardinalCompassPoint.West:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CurrentPosition.FacingCardinalCompassPoint,
                        XPosition = CurrentPosition.XPosition - 1,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.East:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CurrentPosition.FacingCardinalCompassPoint,
                        XPosition = CurrentPosition.XPosition +1 ,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                    
                case CardinalCompassPoint.North:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CurrentPosition.FacingCardinalCompassPoint,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition+ 1
                    };
                    break;
                    
                case CardinalCompassPoint.South:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CurrentPosition.FacingCardinalCompassPoint,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition-1
                    };
                    break;
                   
            }
            ValidateCurrentPosition();
        }
        private void RotateLeft()
        {
            switch (CurrentPosition.FacingCardinalCompassPoint)
            {
                case CardinalCompassPoint.North:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.West, 
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition 
                    };
                    break;
                case CardinalCompassPoint.West:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.South,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.South:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.East,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.East:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.North,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
            }

            ValidateCurrentPosition();
        }

        private void RotateRight()
        {
            switch (CurrentPosition.FacingCardinalCompassPoint)
            {
                case CardinalCompassPoint.North:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.East,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.West:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.North,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.South:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.West,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
                case CardinalCompassPoint.East:
                    CurrentPosition = new Position()
                    {
                        FacingCardinalCompassPoint = CardinalCompassPoint.South,
                        XPosition = CurrentPosition.XPosition,
                        YPosition = CurrentPosition.YPosition
                    };
                    break;
            }

            ValidateCurrentPosition();

        }


        private void ValidateCurrentPosition()
        {
            if (CurrentPosition.XPosition > Arena.MaxXPositions || CurrentPosition.YPosition > Arena.MaxYPositions)
            {
                throw new InvalidPositionException($"Invalid position {CurrentPosition.XPosition} - {CurrentPosition.YPosition}. Max allowed {Arena.MaxXPositions} - {Arena.MaxYPositions}");
            }

            if (CurrentPosition.XPosition < 0 || CurrentPosition.YPosition < 0)
            {
                throw new InvalidPositionException($"Invalid position {CurrentPosition.XPosition} - {CurrentPosition.YPosition}");
            }
        }

        private CardinalCompassPoint GetCardinalCompassPointFromChar(char point)
        {
            CardinalCompassPoint cardinalCompassPoint;
            switch (point)
            {
                case 'N': 
                    cardinalCompassPoint =  CardinalCompassPoint.North;
                    break;
                case 'S': 
                    cardinalCompassPoint = CardinalCompassPoint.South;
                    break;
                case 'E': 
                    cardinalCompassPoint = CardinalCompassPoint.East;
                    break;
                case 'W': 
                    cardinalCompassPoint = CardinalCompassPoint.West;
                    break;
                default:
                    throw new InvalidPositionException($"Invalid initial cardinal point {point}");

            }

            return cardinalCompassPoint;
        }

        private DirectionToMove GetDirectionFromChar(char direction)
        {
            DirectionToMove newDirection;
            switch (direction)
            {
                case 'M': 
                    newDirection =  DirectionToMove.Move;
                    break;
                case 'L': 
                    newDirection = DirectionToMove.Left;
                    break;
                case 'R':
                    newDirection = DirectionToMove.Right;
                    break;
                default:
                    throw new UnrecognisedDirectionMoveException($"Direction {direction} is not recognised as valid");
                    break;
            }

            return newDirection;
        }
    }
}
