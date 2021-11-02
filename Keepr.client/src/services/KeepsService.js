import { AppState } from "../AppState"
import { Keep } from "../Models/Keep"
import { VaultKeep } from "../Models/VaultKeep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{
  async getKeeps(){
    AppState.keeps = []
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.map(k => new Keep(k))
    }
    async getKeepById(keepId){
    AppState.keep = []
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.keep = new Keep(res.data)
    }

    async getKeepsByProfile(profileId){
      AppState.keeps = []
      const res = await api.get(`api/profiles/${profileId}/keeps`)
      AppState.keeps = res.data.map(k => new Keep(k))
      logger.log('keeps by profile', AppState.keeps)
    }
    
    async getKeepsByVaultId(vaultId){
      AppState.keeps = []
      const res = await api.get(`api/vaults/${vaultId}/keeps`)
      AppState.keeps = res.data.map(k => new Keep(k))
      logger.log('get keeps by vault id', AppState.keeps)
    }
    
    async createKeep(keep){
    const res = await api.post('api/keeps', keep)
    AppState.keeps.push(new Keep(res.data))
    }

    async createVaultKeep(vaultId, keepId){
      const vaultKeep = {}
      vaultKeep.vaultId = vaultId
      vaultKeep.keepId = keepId
      const res = await api.post('api/vaultkeeps', vaultKeep)
      AppState.vaultKeeps.push(new VaultKeep(res.data))
      logger.log('create vault keep res.data', AppState.vaultKeeps)
    }
    
    async editKeep(keep){
    const res = await api.put(`api/keeps/${keep.id}`, keep)
    AppState.keeps = new Keep(res.data)
    }
    
    async deleteKeep(keepId){
    const res = await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(v => v.id !== keepId)
    }

    async deleteVaultKeep(vaultKeepId){
      const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
      AppState.vaultKeeps = AppState.vaultKeeps.filter(v => v.id !== vaultKeepId)
    }
}
export const keepsService = new KeepsService();