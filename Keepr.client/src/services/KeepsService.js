import { AppState } from "../AppState"
import { Keep } from "../Models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{
  async getKeeps(){
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
    }
    async getKeepById(keepId){
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.keep = new Keep(res.data)
    }

    async getKeepsByProfile(profileId){
      AppState.keeps = []
      const res = await api.get(`api/profiles/${profileId}/keeps`)
      AppState.keeps = res.data.map(k => new Keep(k))
    }
    
    async createKeep(keep){
    const res = await api.post('api/keeps', keep)
    AppState.keeps.push(new Keep(res.data))
    }
    
    async editKeep(keep){
    const res = await api.put(`api/keeps/${keep.id}`, keep)
    AppState.keeps = new Keep(res.data)
    }
    
    async deleteKeep(keepId){
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(v => v.id !== keepId)
    }
}
export const keepsService = new KeepsService();