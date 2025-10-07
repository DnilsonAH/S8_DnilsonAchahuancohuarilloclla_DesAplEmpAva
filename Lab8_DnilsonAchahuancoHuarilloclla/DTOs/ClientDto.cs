namespace Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

public class ClientDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class CreateClientDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class UpdateClientDto
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

public class ClientWithOrderCountDto
{
    public int ClientId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int OrderCount { get; set; }
}