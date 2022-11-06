import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{

  async getKeeps() {
    const res = await api.get("api/keeps")
    AppState.keeps = res.data.map(r => new Keep(r))
    console.log(AppState.keeps);
  }

  async getKeepDetails(id) {
    const res = await api.get(`api/keeps/${id}`)
    // console.log(res.data);
    AppState.activeKeep = new Keep(res.data)
    console.log(AppState.activeKeep);

  }


}

export const keepsService = new KeepsService()