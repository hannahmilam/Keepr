<template>
<div class="grid-item my-3" v-if="keep != null">
  <div class="card p-0 m-0 selectable" :style="{ 'backgroundImage': `url(${keep.img})` }">
    <div class="card-body selectable " data-bs-toggle="modal" :data-bs-target="'#keep-details-'+keep.id"></div>
    <div class="card-footer m-0 p-0">
      <div class="row mt-1 pb-1 justify-content-around">
      <div class="col-8">
      <h4 class="clip-text">{{keep.name}}</h4>
      </div>
      <div class="col-2">
        <!-- <router-link :to="{name: 'Profile', params: {profileId: keep.creator?.id}}" class="selectable"> -->
        <img :src="keep.creator?.picture" class="rounded-circle action" height="35" alt="" @click="goToProfile">
        <!-- </router-link> -->
      </div>
      </div>
    </div>
</div>
  </div>


<Modal :id="'keep-details-'+keep.id">
    <template #modal-body>
      <KeepDetails :keep="keep"/>
    </template>
  </Modal>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
import { Modal } from 'bootstrap'
import { router } from '../router'
export default {
  props: {
    keep: { 
      type: Keep,
      default: () => { return new Keep()}
    }
  },
setup(props){
  return{
        goToProfile() {
          const modal = Modal.getOrCreateInstance(document.getElementById(`keep-details-${props.keep.id}`))
          modal.hide()
          router.push({ name: 'Profile', params: { profileId: props.keep.creatorId}})
      }
  }
}
}
</script>

<style scoped style="scss">
.card{
  height: 20rem;
  background-size: cover;
  border-radius: 12px; 
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
}
.card-footer{
  border: none;
  backdrop-filter: blur(12px);
  background-color: transparent;
}
h4 {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
  border-radius: 12px; 

}

  /* @media only screen and (max-width: 768px) {
     .hidden-text {
       display: none;
     } */
</style>