﻿using System.Threading.Tasks;

namespace Astronomy
{
    public interface ILatLongService
    {
        Task<(double Latitude, double Longitude)> GetLatLong();
    }
}