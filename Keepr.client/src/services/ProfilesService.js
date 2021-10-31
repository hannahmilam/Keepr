import { AppState } from "../AppState";
import { Profile } from "../Models/Profile";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";

class ProfilesService{

  async getProfileById(profileId){
    AppState.currentProfile = []
    const res = await api.get(`api/profiles/${profileId}`)
    logger.log('get profile by id res', res)
    AppState.currentProfile = new Profile(res.data)
  }
}
export const profilesService = new ProfilesService();