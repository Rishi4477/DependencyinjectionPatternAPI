using System;
using System.Collections.Generic;

namespace EntityFrameWork.Entities;

public partial class Center
{
    public int Id { get; set; }

    public string Scheme { get; set; } = null!;

    public string SubScheme { get; set; } = null!;

    public string MonitoringAgency { get; set; } = null!;

    public string SponsoredAgency { get; set; } = null!;

    public string CentreName { get; set; } = null!;

    public string CentreSpocname { get; set; } = null!;

    public string Spocemail { get; set; } = null!;

    public string SpocmobileNo { get; set; } = null!;

    public string ParliamentaryConstituency { get; set; } = null!;

    public string AssemblyConstituency { get; set; } = null!;

    public string State { get; set; } = null!;

    public string District { get; set; } = null!;

    public string? Block { get; set; }

    public string? PoliceStation { get; set; }

    public string? Village { get; set; }

    public string? PostOffice { get; set; }

    public string? Landmark { get; set; }

    public string PinCode { get; set; } = null!;

    public string AreaType { get; set; } = null!;

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }
}
