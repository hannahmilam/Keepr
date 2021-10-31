<template>
<div class="col-3">
  <h3>{{vault.name}}</h3>
  <p>{{vault.description}}</p>
</div>

</template>

<script>
import { Vault } from '../Models/Vault'
export default {
  props: {
    vault: {
      type: Vault,
      default: () => { return new Vault()}
    }
  },
  setup(){
    return{

    }
  }

}
</script>

<style>

</style>