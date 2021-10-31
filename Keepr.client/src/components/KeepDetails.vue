<template>
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
        <h2 class="text-center">{{keep.name}}</h2>
        <p class="mx-3">{{keep.description}}</p>

      <div class="row mb-2 justify-content-around">
      
        <div class="col-5 text-center m-0 p-0">
        <button class="btn btn-outline-info m-0 px-1"><small>ADD TO VAULT</small></button>
        </div>
        <div class="col-1 text-center m-0 p-0" v-if="keep.creatorId = account.id">
          <i class="mdi mdi-delete"></i>
        </div>
        <div class="col-5 text-center m-0 p-0">
          <img :src="keep.creator?.picture" height="40" class="rounded-circle" alt="">
          </div>
          </div>
        </div>
      </div>

</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
export default {
props: {
  keep: {
    type: Keep,
    default: () => {return new Keep()}
  }
},
  setup(){
    return{
      account: computed(() => AppState.account)

    }
  }

}
</script>

<style scoped>
.details-img{
  background-size: cover;
  width: 100%;
}
</style>