<template>
    <div class="row mt-2">
        <div class="col-1 offset-11">
           <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
      </div>

       <div class="row mb-3">
          <div class="col-4 ms-5">
        <h2>New Keep</h2>
        </div>
        </div>

       <div class="row justify-content-center">
    <div class="col-11">
     <form @submit.prevent="submitForm">
    <div class="form-group">
      <label for="name" class="sr-only">Name</label>
      <input type="text"
             class="form-control bg-white"
             name="name"
             id="name"
             placeholder="Keep Name..."
             v-model="editable.name"
             required
      >
    </div>

  <div class="form-group my-4">
      <label for="img" class="sr-only">Image URL</label>
      <input type="url"
             class="form-control bg-white"
             name="img"
             id="img"
             placeholder="Keep Image..."
             v-model="editable.img"
             required
      >
    </div>

    <div class="form-group">
      <label for="description" class="sr-only">Description</label>
      <input type="text"
             class="form-control bg-white"
             name="description"
             id="description"
             placeholder="Keep Description..."
             style="height: 100px"
             v-model="editable.description"
             required
      >
    </div>
  

    <div>
      <div class="row mb-3">
        <div class="col-3 text-end offset-9">
      <button class="btn btn-primary mt-4" data-bs-dismiss="modal">
        Create Keep
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
import { Keep } from '../Models/Keep'
import { watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
export default {
  props: {
    keep: {
      type: Keep,
      default: () => {return new Keep()}
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
            await keepsService.editKeep(editable.value)
          } else {
            await keepsService.createKeep(editable.value)
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