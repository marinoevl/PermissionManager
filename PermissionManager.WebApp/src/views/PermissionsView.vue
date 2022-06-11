<template>
  <div class="row">
    <PermissionList :data="permissions" 
                    @on-delete-row="onDeleteRow"
                    @on-edit-row="onEditRow"/>
  </div>
</template>

<script setup>
import { usePermissionStore } from '../stores/permission.js'
import PermissionList from "../components/PermissionList.vue";
import {onMounted} from "vue";
import {storeToRefs} from "pinia/dist/pinia";
import {useRouter} from "vue-router";

const { permissions } = storeToRefs(usePermissionStore())
const { load } = usePermissionStore()
const router = useRouter();

load()
onMounted(() => {
  // console.log(permissions)  
})

function onEditRow(event) {
  // console.log(event)
  // console.log(event.id)
  
  router.push(`/permission/${event.id.toString()}`);
}

function onDeleteRow(event) {
  console.log(event)
}

</script>


<style scoped>

</style>