﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using teen_patti.common.Models.ViewModel;

namespace teen_patti.common.Models.Engine
{
    public class Player
    {
        private readonly Guid _id;
        private readonly int _ordinal;
        private IReadOnlyCollection<Card> _hand;

        public ICollection<Card> Hand { get => _hand.ToList(); }
        public Guid Id { get => _id; }
        public int Ordinal { get => _ordinal; }
        public Player(Guid playerId, ICollection<Card> hand, int ordinal)
        {
            _id = playerId;
            _ordinal = ordinal;

            if (hand.Count > 3)
                throw new ArgumentException($"Hand cannot be greater than three cards. Hand passed in contianed {hand.Count} cards.");

            hand.CopyTo(_hand.ToArray(), 0);
        }
        public Player(Persistence.Player persistence, int ordinal)
        {
            _id = persistence.Id;
            _ordinal = ordinal;
            _hand = new List<Card>();
        }
    }
}

