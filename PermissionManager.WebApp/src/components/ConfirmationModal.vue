<template>
  <div id="exampleModal" aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" tabindex="-1">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 id="exampleModalLabel" class="modal-title">Modal title</h5>
          <button aria-label="Close" class="btn-close" data-bs-dismiss="modal" type="button"></button>
        </div>
        <div class="modal-body">
          ...
        </div>
        <div class="modal-footer">
          <button class="btn btn-secondary" data-bs-dismiss="modal" type="button">Close</button>
          <button class="btn btn-primary" type="button" @click="confirm">Save changes</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>

import {onMounted} from "vue";
import { Modal } from 'bootstrap'

const emit = defineEmits(['onConfirm'])

let myModal = null

onMounted(() => {
  myModal = new Modal(document.getElementById('exampleModal'), {})
})

function confirm() {
   myModal.hide('exampleModal'); 
   console.log('hide')
  // emit('onConfirm')
}

</script>

<style scoped>

</style>