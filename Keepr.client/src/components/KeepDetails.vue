<template>
<!-- <div class="card" v-if="keep"> -->
<div class="row" v-if="keep">
      <div class="col-md-6">
      <img :src="keep.img" class="details-img rounded-start" alt="">
      </div>

      <div class="col-md-6 d-flex details-col">
          <div class="row mt-2">
        <div class="col-2 offset-10">
           <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
          </div>

          <div class="row justify-content-center mt-4">
            <div class="col-1 ms-3 text-center">
             <i class="mdi mdi-eye"> </i>
            </div>
            <div class="col-1">
              <span> {{keep.views}} </span>
            </div>
            <div class="col-1 text-center">
             <i class="mdi mdi-alpha-k-box-outline"></i>
            </div>
            <div class="col-1">
              <span> {{keep.keeps}} </span>
            </div>
            <div class="col-1 me-3 text-center">
              <i class="mdi mdi-share-variant"></i>
            </div>
          </div>

        <div class="row my-3 flex-grow">
        <h2 class="text-center">{{keep.name}}</h2>
        <p class="mx-3">{{keep.description}}</p>
        </div>
        
      <!-- <div class="card-footer mb-0 p-0 bg-transparent my-2 justify-content-around"> -->
        <div class="row justify-content-center p-0">
        <div class="col-5 p-0">
          <div class="input-group  mb-3">
        <button class="btn btn-outline-info dropdown-toggle m-0 px-1" data-bs-toggle="dropdown" aria-expanded="false"><small>Add To Vault</small></button>
        <ul class="dropdown-menu">
          <li><a class="dropdown-item" href="#" v-for="v in vaults" :key="v.id" :vaults="v" @click="createVaultKeep(v.id, keep.id)">{{v.name}}</a></li>
          </ul>
        </div>
        </div>
        <div class="col-1 text-center" v-if="keep.creatorId === account.id">
          <i class="mdi mdi-delete selectable" @click="deleteKeep(keep.id)"></i>
        </div>
        <div class="col-5 profile text-center">
          <img :src="keep.creator?.picture" height="40" class="rounded-circle action" alt="" @click="goToProfile">
          </div>
          
        </div>
        </div>
      </div>
      <!-- </div> -->
  <!-- </div> -->
</template>

<script>
import { computed, ref } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
import { useRoute } from 'vue-router'
import { router } from '../router'
import { Modal } from 'bootstrap'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { onMounted } from '@vue/runtime-core'
import { vaultsService } from '../services/VaultsService'
export default {
// props: {
//   keep: {
//     type: Keep,
//     default: () => {return new Keep()}
//   }
// },
  setup(){
    // const viewCount = ref(props.keep.views)
    return{
      // viewCount,
      // props,
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.accountVaults),
      keep: computed(() => AppState.keep),
      goToProfile() {
       const modal = Modal.getInstance(document.getElementById(`keep-details-${this.keep.id}`))
        modal.hide()
        router.push({ name: 'Profile', params: { profileId: this.keep.creatorId}})
      },
      async deleteKeep(keepId){
        try {
          if(await Pop.confirm()){
            const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${keepId}`))
            modal.hide()
            await keepsService.deleteKeep(keepId)
            Pop.toast('Keep Deleted')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log('ERROR_DELETING_KEEP', error.message)
        }
      },
      async createVaultKeep(vaultId, keepId){
        try {
          if(await Pop.confirm('Are you sure?', '', 'info', 'Yes, save keep to vault!')) {
            const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${this.keep.id}`))
            modal.hide()
            await keepsService.createVaultKeep(vaultId, keepId)
            Pop.toast('keep added to vault', 'success')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log('CREATE_VAULT_KEEP_ERROR', error.message)
        }
      }

    }
  }

}
</script>

<style scoped>
.details-img{
  background-size: cover;
  width: 100%;
  height: 100%;
}
.details-col{
  flex-direction: column;
}
.flex-grow{
  flex-grow: 1;
}
</style>