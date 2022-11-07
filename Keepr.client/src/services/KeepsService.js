import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(r => new Keep(r))
    console.log(AppState.keeps);
  }

  async getKeepDetails(id) {
    const res = await api.get(`api/keeps/${id}`)
    // console.log(res.data);
    AppState.activeKeep = new Keep(res.data)
    if (AppState.keeps.creatorId != AppState.account.id) {

      AppState.activeKeep.views++
    }
    console.log(AppState.activeKeep);
  }

  async createKeep(data) {
    const res = await api.post("api/keeps", data)
    console.log(res.data);
    AppState.keeps = [new Keep(res.data), ...AppState.keeps]
  }

  async removeKeep(id) {
    await api.delete(`api/keeps/${id}`)

    AppState.keeps = AppState.keeps.filter(k => k.id !== id)

  }
}

export const keepsService = new KeepsService()