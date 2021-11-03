 <template>
  <div class="row" v-if="keep">
    <div class="col-md-6">
      <img :src="keep.img" class="details-img rounded-start" alt="" />
    </div>

    <div class="col-md-6 d-flex details-col">
      <div class="row mt-2">
        <div class="col-2 offset-10">
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
            title="close"
          ></button>
        </div>
      </div>

      <div class="row justify-content-center mt-4">
        <div class="col-1 ms-3 text-center">
          <i class="mdi mdi-eye" title="views"> </i>
        </div>
        <div class="col-1">
          <span> {{ keep.views }} </span>
        </div>
        <div class="col-1 text-center">
          <i class="mdi mdi-alpha-k-box-outline" title="keeps"></i>
        </div>
        <div class="col-1">
          <span> {{ keep.keeps }} </span>
        </div>
        <div class="col-1 me-3 text-center">
          <i class="mdi mdi-share-variant" title="shares"></i>
        </div>
      </div>

      <div class="row mt-3 flex-grow">
        <h2 class="text-center">{{ keep.name }}</h2>
        <p class="mx-3">{{ keep.description }}</p>
      </div>

      <div class="row justify-content-center mb-3 p-0">
        <div class="col-8 text-center m-0 p-0">
          <button
            class="btn btn-outline-secondary"
            v-if="vault.creatorId === account.id"
            @click="deleteVaultKeep(keep.vaultKeepId, keep.id)"
          >
            Remove From Vault
          </button>
        </div>
        <div class="col-1 text-center m-0 p-0">
          <img
            :src="keep.creator?.picture"
            height="40"
            class="rounded-circle action"
            alt=""
            @click="goToProfile"
          />
        </div>
      </div>
    </div>
  </div>
</template>
 
<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Modal } from 'bootstrap'
import { router } from '../router'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'

export default {

  setup() {

    return {
      account: computed(() => AppState.account),
      keep: computed(() => AppState.keep),
      vaults: computed(() => AppState.accountVaults),
      vault: computed(() => AppState.vault),
      profileVaults: computed(() => AppState.profileVaults),
      goToProfile() {
        const modal = Modal.getInstance(document.getElementById(`vaultkeep-details-${this.keep.id}`))
        modal.hide()
        router.push({ name: 'Profile', params: { profileId: this.keep.creatorId } })
      },
      async deleteVaultKeep(vaultKeepId, keepId) {
        try {
          if (await Pop.confirm()) {
            const modal = Modal.getOrCreateInstance(document.getElementById(`vaultkeep-details-${keepId}`))
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
.details-img {
  background-size: cover;
  width: 100%;
  height: 100%;
}
.details-col {
  flex-direction: column;
}
.flex-grow {
  flex-grow: 1;
}
p {
  width: 10rem;
}
</style>