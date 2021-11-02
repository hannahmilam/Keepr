 <template>
 <div class="card">
   <div class="row">
      <div class="col-md-6">
      <img :src="keep.img" class="details-img rounded-start" alt="">
      </div>

      <div class="col-md-6">
          <div class="row mt-2">
        <div class="col-2 offset-10">
           <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
          </div>

         <div class="row justify-content-around mt-4">
            <div class="col-1 text-center ms-3">
              <h5><i class="mdi mdi-eye"></i></h5>
            </div>
            <div class="col-1 text-center">
              <h5><i class="mdi mdi-alpha-k-box-outline"></i></h5>
            </div>
            <div class="col-1 me-5 text-center">
               <h5><i class="mdi mdi-share-variant"></i></h5>
            </div>
         <div class="row mb-2 justify-content-around">

        <div class="card-body my-3">
        <h2 class="text-center">{{keep.name}}</h2>
        <p class="mx-3">{{keep.description}}</p>
        </div>
        </div>
      
        
        <div class="card-footer mt-1 p-0 bg-transaprent my-3">
          <div class="row m-0 p-0">
        <div class="col-8 text-center m-0 p-0">
          <button class="btn btn-outline-secondary" @click="deleteVaultKeep(keep.vaultKeepId)">Remove From Vault</button>
          </div>
        <div class="col-1 text-center m-0 p-0">
          <img :src="keep.creator?.picture" height="40" class="rounded-circle action" alt="" @click="goToProfile">
          </div>
          </div>
          </div>
          
        </div>
        </div>
      </div>
      </div>
      </template>
 
<script>
import { computed } from '@vue/reactivity'
import { Keep } from '../Models/Keep'
import { AppState } from '../AppState'
import { Modal } from 'bootstrap'
import { router } from '../router'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'

export default {
props: {
  keep: {
    type: Keep,
    default: () => {return new Keep()}
  }
},
  setup(props){
    return{
      props,
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults.filter(v => v.creator.id === AppState.account.id)),
      goToProfile() {
       const modal = Modal.getInstance(document.getElementById(`vaultkeep-details-${props.keep.id}`))
        modal.hide()
        router.push({ name: 'Profile', params: { profileId: props.keep.creatorId}})
      },
      async deleteVaultKeep(vaultKeepId){
        try {
          if(await Pop.confirm()){
            const modal = Modal.getOrCreateInstance(document.getElementById(`vaultkeep-details-${props.keep.id}`))
            modal.hide()
            await keepsService.deleteVaultKeep(vaultKeepId)
            Pop.toast('Keep Deleted')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log('ERROR_DELETING_KEEP', error.message)
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
  max-height: 20rem;
}
.card{
  min-width: 35rem;
  max-height: 20rem;
}
.card-footer{
  border: none;
}
 </style>