namespace Keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepo;

  public VaultsService(VaultsRepository vaultsRepo)
  {
    _vaultsRepo = vaultsRepo;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    return _vaultsRepo.CreateVault(vaultData);
  }

  internal Vault GetVaultById(int vaultId)
  {
    var vault = _vaultsRepo.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception("Bad Vault Id");
    }
    return vault;
  }

  internal Vault EditVault(Vault vault, string userId)
  {
    var original = GetVaultById(vault.Id);
    if (vault.CreatorId != userId)
    {
      throw new Exception("Unauthorized To Edit This Keep");
    }

    original.Name = vault.Name;
    original.Img = vault.Img ?? original.Img;
    original.Description = vault.Description ?? original.Description;


    var updated = _vaultsRepo.UpdateVault(original);
    return updated;
  }

  internal void DeleteVault(int vaultId, string userId)
  {
    var vault = GetVaultById(vaultId);
    if(vault.CreatorId != userId)
    {
      throw new Exception("No not yours....");
    }
    _vaultsRepo.DeleteVault(vaultId);
  }
}