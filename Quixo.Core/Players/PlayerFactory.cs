﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quixo.Core.Players
{
    public class PlayerFactory
    {
        private static PlayerFactory _instance;

        public static PlayerFactory Instance()
        {
            if (_instance == null)
            {
                _instance = new PlayerFactory();
            }

            return _instance;
        }

        private PlayerFactory()
        {
        }

        public Player CreatePlayer(PlayerType playerType, int id, string name, PieceType pieceType)
        {
            if (playerType == PlayerType.Human)
            {
                return CreateHumanPlayer(id, name, pieceType);
            }
            else if (playerType == PlayerType.RandomAi)
            {
                return CreateRandomAiPlayer(id, name, pieceType);
            }
            else if (playerType == PlayerType.EasyAi)
            {
                return CreateMinMaxAiPlayer(id, name, pieceType);
            }
            else if (playerType == PlayerType.HardAi)
            {
                return CreateMinMaxAiPlayer(id, name, pieceType);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Player CreateHumanPlayer(int id, string name, PieceType pieceType)
        {
            return new HumanPlayer(id, name, pieceType);
        }

        public Player CreateRandomAiPlayer(int id, string name, PieceType pieceType)
        {
            return new RandomAiPlayer(id, name, pieceType);
        }

        public Player CreateMinMaxAiPlayer(int id, string name, PieceType pieceType)
        {
            return new MinMaxAiPlayer(id, name, pieceType);
        }
    }
}
