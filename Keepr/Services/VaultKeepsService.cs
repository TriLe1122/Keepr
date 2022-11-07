namespace Keepr.Services;


public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkRepo;
  private readonly VaultsService _vs;

  public VaultKeepsService(VaultKeepsRepository vkRepo, VaultsService vs)
  {
    _vkRepo = vkRepo;
    _vs = vs;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    var cat =  _vkRepo.CreateVaultKeep(vaultKeepData);
    if (cat.CreatorId != vaultKeepData.CreatorId)
    {
      throw new Exception("bad kitty");
    }
    return cat;
  }

  // internal List<KeepInVault> GetKeepsByVaultId(int vaultId)
  // {
  //   Vault vault = _vs.GetVaultKeepById()
  //   KeepInVault kv = _vkRepo.GetKeepsByVaultId(vaultId);
  // }

  internal List<VaultKeep> GetAllVaultKeeps()
  {
    return _vkRepo.GetAllVaultKeeps();
  }

  internal void DeleteVaultKeep(int vaultKeepId, string accountId)
  {
    var vk = GetVaultKeepById(vaultKeepId);
    if (vk.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete VaultKeep");
    }
    _vkRepo.DeleteVaultKeep(vaultKeepId);
  }


  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    var vk = _vkRepo.GetVaultKeepById(vaultKeepId);
    if (vk == null)
    {
      throw new Exception("Bad VaultKeep Id");
    }
    return vk;
  }

  
}