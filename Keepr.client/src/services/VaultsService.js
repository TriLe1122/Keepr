import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { Vault } from "../models/Vault.js";
import { router } from "../router.js";
import { api } from "./AxiosService.js"

class VaultsService {
  async createVault(data) {
    const res = await api.post("api/vaults", data)
    console.log(res.data, 'res');
  }

  async getKeepsInVault(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    console.log(res.data);
    AppState.keeps = res.data.map(k => new Keep(k))
  }

  async removeVault(id) {
    const res = await api.delete(`/api/vaults/${id}`)
    if (res) {
      router.push({ name: 'Account' })

    }
    // AppState.activeVault = AppState.activeVault.filter()
  }

  async setVaultActive(id) {
    const res = await api.get(`api/vaults/${id}`)
    console.log(res.data);
    let vault = new Vault(res.data)
    // let userId = AppState.account.id
    // let notOwner = userId == vault.creator.id
    // if (vault.isPrivate && notOwner) {
    //   router.push({
    //     name: 'Home'
    //   })
    //   return
    // }
    AppState.activeVault = vault

    console.log(AppState.activeVault);


  }

  async addToVault(vaultData) {
    console.log(vaultData);
    const res = await api.post(`api/vaultkeeps`, vaultData)
    AppState.activeKeep.kept++
    console.log(res.data);
  }
}

export const vaultsService = new VaultsService()