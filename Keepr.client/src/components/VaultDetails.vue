<template>
<p>testing from vault details component</p>

</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
import { Vault } from '../Models/Vault'
export default {
props: {
  vault: {
    type: Vault,
    default: () => {return new Vault()}
  }
},
 setup(){
    return{
      account: computed(() => AppState.account),
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