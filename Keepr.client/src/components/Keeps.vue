<template>
<div class="grid-item my-3" v-if="keep">
  <div class="card p-0 m-0 selectable">
    <div class="card-body m-0 p-0 selectable " @click="getById" data-bs-toggle="modal" :data-bs-target="'#keep-details-'+keep.id">
      <img :src="keep.img" class="card-img"  alt="keep image">
    </div>
    <div class="card-footer m-0 p-0">
      <div class="row mt-1 pb-1 justify-content-around">
      <div class="col-8">
      <h4 class="clip-text">{{keep.name}}</h4>
      </div>
      <div class="col-2 me-2">
        <img :src="keep.creator?.picture" class="rounded-circle action" height="35" alt="" @click="goToProfile">
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
import { keepsService } from '../services/KeepsService'
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
      },
      async getById(){
        await keepsService.getKeepById(props.keep.id)
      }
  }
}
}
</script>

<style scoped style="scss">
.grid-item{
  display: inline-block;
}
.card{
  max-width: 20rem;
  border-radius: 12px; 
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
}
.card-img{
  height: 100%;
  border-radius: 12px;
}
.card-body{
  border-radius: 12px;
}
.card-footer{
  position: absolute;
  width: 100%;
  bottom: 0;
  border: none;
  backdrop-filter: blur(12px);
  background-color: transparent;
  border-radius: 12px;
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