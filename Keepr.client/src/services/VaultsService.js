import { AppState } from "../AppState"
import { Vault } from "../Models/Vault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService {

async getVaults(){
const res = await api.get('api/vaults')
AppState.vaults = res.data.map(v => new Vault(v))
}
async getVaultById(vaultId){
const res = await api.get(`api/vaults/${vaultId}`)
AppState.vault = new Vault(res.data)
}

async getVaultsByProfile(profileId){
  AppState.vaults = []
  const res = await api.get(`api/profiles/${profileId}/vaults`)
  AppState.vaults = res.data.map(v => new Vault(v))
}

async createVault(vault){
const res = await api.post('api/vaults', vault)
AppState.vaults.push(new Vault(res.data))
return res.data.id
}

async editVault(vault){
const res = await api.put(`api/vaults/${vault.id}`, vault)
AppState.vaults = new Vault(res.data)
}

async deleteVault(vaultId){
const res = await api.delete(`api/vaults/${vaultId}`)
AppState.vaults = AppState.vaults.filter(v => v.id !== vaultId)
}
}

export const vaultsService = new VaultsService()