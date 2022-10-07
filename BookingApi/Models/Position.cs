﻿using System.Text.Json.Serialization;

namespace BookingApi.Models;

    public class Position
    {
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lng")]
        public double Longitude { get; set; }
    }