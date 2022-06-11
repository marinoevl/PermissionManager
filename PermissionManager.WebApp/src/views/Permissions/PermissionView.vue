<template>
  <h1>Permission View</h1>
  <form class="row g-3">
    <div class="col-md-6">
      <InputDefault id="firstName" for="firstName" label="First Name" v-model="permission.firstName" type="text"/>
    </div>
    <div class="col-md-6">
      <InputDefault id="lastName" for="lastName" label="Last Name" v-model="permission.lastName" type="text"/>
    </div>

    <div class="col-md-4">
      <InputSelectDefault 
          label="Permission Type" 
          placeholder="Please select one" 
          v-model="permission.permissionTypeId"
          :options="types"
      />
    </div>
    <div class="col-md-2">
      <InputDateDefault label="Date At" v-model="permission.permissionDate" />
    </div>
    <div class="col-12">
      <button class="btn btn-primary m-1" @click.prevent="onSubmit">{{ commandLabel }}</button>
      <button class="btn btn-secondary m-1" @click.prevent="cancel">Cancel</button>
    </div>
  </form>
</template>

<script setup>
import {storeToRefs} from "pinia/dist/pinia";
import {usePermissionStore} from "../../stores/permission";
import {useRoute, useRouter} from "vue-router";
import InputDefault from "../../components/InputDefault.vue";
import InputSelectDefault from "../../components/InputSelectDefault.vue";
import InputDateDefault from "../../components/InputDateDefault.vue";

const { permission, types, isEdit } = storeToRefs(usePermissionStore())
const { getById, create, update, reset } = usePermissionStore()
const router = useRouter();
const route = useRoute();

if (route.params.id)
  getById(route.params.id)
else 
  reset()

let commandLabel = isEdit.value === true ? "Edit": "Create" 

async function onSubmit() {
  if (isEdit.value)
    await update(route.params.id)
  else
    await create()
  router.push(`/`);
}
function cancel() {  
  reset()
  router.back()  
}
</script>

<style scoped>

</style>