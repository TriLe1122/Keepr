namespace Keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepo;
  private readonly VaultKeepsRepository _vkRepo;

  public VaultsService(VaultsRepository vaultsRepo, VaultKeepsRepository vkRepo)
  {
    _vaultsRepo = vaultsRepo;
    _vkRepo = vkRepo;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    return _vaultsRepo.CreateVault(vaultData);
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = _vaultsRepo.GetVaultById(vaultId);
    if (vault.Id == 0)
    {
      throw new Exception("not your vault");
    }

    if (vault == null)
    {
      throw new Exception("Bad Vault Id");
    }
    if (vault.IsPrivate == true)
    {
      if (vault.CreatorId != userId)
      {
        throw new Exception("This is a vault you don't have access too");
      }
    }
    return vault;
  }

  internal Vault EditVault(Vault vault, string userId)
  {

    var original = GetVaultById(vault.Id, userId);
    if (original.CreatorId != userId)
    {
      throw new Exception("Unauthorized To Edit This Keep");
    }


    original.Name = vault.Name ?? original.Name;
    original.Img = vault.Img ?? original.Img;
    original.Description = vault.Description ?? original.Description;
    original.IsPrivate = vault.IsPrivate ?? original.IsPrivate;


    var updated = _vaultsRepo.EditVault(original);
    return updated;
  }

  internal void DeleteVault(int vaultId, string userId)
  {
    var vault = GetVaultById(vaultId, userId);
    if (vault.CreatorId != userId)
    {
      throw new Exception("No not yours....");
    }
    _vaultsRepo.DeleteVault(vaultId);
  }

 

  internal List<KeepInVault> GetKeepsByVaultId(int vaultId, string id)
  {
    Vault vault = GetVaultById(vaultId, id);

    List<KeepInVault> keeps = _vkRepo.GetKeepsByVaultId(vaultId);
    return keeps;

  }
}