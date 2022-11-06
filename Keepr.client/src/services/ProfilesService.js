import { AppState } from "../AppState.js";
import { Account } from "../models/Account.js";
import { api } from "./AxiosService.js"

class ProfilesService {
  async getProfile(id) {
    const res = await api.get(`api/profiles/${id}`)
    // console.log(res.data);
    console.log(res.data);
    AppState.activeProfile = new Account(res.data)
    console.log(AppState.activeProfile);
  }
}


export const profilesService = new ProfilesService()