import { api } from "./AxiosService.js"

class VaultsService{
  async createVault(data) {
    const res = await api.post("api/vaults", data)
    console.log(res.data);
}
}

export const vaultsService = new VaultsService()