<template>
    <div class="row mt-2">
        <div class="col-1 p-2 offset-10">
           <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
        </div>

      <div class="row mb-3">
        <div class="col-4 ms-5">
        <h2>New Vault</h2>
        </div>
      </div>
     
<div class="row justify-content-center">
  <div class="col-11">
      <form @submit.prevent="submitForm">
    <div class="form-group">
      <label for="name" class="sr-only">Name</label>
      <input type="text"
             class="form-control"
             name="name"
             id="name"
             placeholder="Vault Name..."
             v-model="editable.name"
             required
      >
    </div>

    <div class="form-group my-4">
      <label for="description" class="sr-only">Description</label>
      <input type="text"
             class="form-control bg-light"
             name="description"
             id="description"
             placeholder="Vault Description..."
             v-model="editable.description"
             required
      >
    </div>

      <div class="form-check form-switch">
          <input class="form-check-input" type="checkbox" id="private">
          <label class="form-check-label" for="closed">
            <p class="mb-0 pb-0">Private? </p>
            <small><em>private vaults can only be seen by you</em></small>
          </label>
        </div>
    <div>

      <div class="row mb-3">
        <div class="col-3 text-end offset-9">
      <button class="btn btn-primary mt-4" data-bs-dismiss="modal">
        Create Vault
      </button>
        </div>
    </div>
    </div>
  </form>
   </div>
   </div>
</template>

<script>
import { ref } from '@vue/reactivity'
import { Vault } from '../Models/Vault'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { watchEffect } from '@vue/runtime-core'
export default {
   props: {
    keep: {
      type: Vault,
      default: () => {return new Vault()}
    }
  },
setup(){
    const editable = ref({})
    watchEffect(() => {
      editable.value = {}
    })
    return{
      editable,
      async submitForm(){
        try {
          if(editable.value.id) {
            await vaultsService.editVault(editable.value)
          } else {
            await vaultsService.createVault(editable.value)
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log('SUBMIT_KEEP_FORM_ERROR', error.message)
        }
      }
    }
  }
}
</script>

<style>

</style>