namespace Keepr.Services;


public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vkRepo;

  public VaultKeepsService(VaultKeepsRepository vkRepo)
  {
    _vkRepo = vkRepo;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    return _vkRepo.CreateVaultKeep(vaultKeepData);
  }

  internal List<KeepInVault> GetKeepsByVaultId(int vaultId)
  {
    return _vkRepo.GetKeepsByVaultId(vaultId);
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