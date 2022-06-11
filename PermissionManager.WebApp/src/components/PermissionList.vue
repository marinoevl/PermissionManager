<template>
  <div class="card">
    <div class="card-body">
      <h5 class="card-title">Permission</h5>
      <button class="btn btn-primary m-1" @click.prevent="onNewPermission">New</button>
      <div class="card-text">
        <table class="table">
          <thead>
          <tr>
            <th scope="col">Id</th>
            <th scope="col">First Name</th>
            <th scope="col">Last Name</th>
            <th scope="col">Permission Type</th>
            <th scope="col">Date At</th>
            <th scope="col"></th>
          </tr>
          </thead>
          <tbody>
          <tr is="vue:PermissionRow"
              v-for="(item, index) in props.data.items"
              :key="index" 
              :item="props.data.items[index]" 
              @on-delete-row="emit('onDeleteRow', item)"
              @on-edit-row="emit('onEditRow', item)"
              >
          </tr>
<!--          <tr>-->
<!--            <th scope="row">2</th>-->
<!--            <td>Jacob</td>-->
<!--            <td>Thornton</td>-->
<!--            <td>@fat</td>-->
<!--            <td>Thornton</td>-->
<!--            <td>-->
<!--              <div>-->
<!--                <button class="btn btn-secondary m-1">Edit</button>-->
<!--                <button class="btn btn-danger" data-bs-target="#exampleModal" data-bs-toggle="modal">Delete</button>-->
<!--              </div>-->
<!--            </td>-->
<!--          </tr>-->
<!--          <tr>-->
<!--            <th scope="row">3</th>-->
<!--            <td colspan="2">Larry the Bird</td>-->
<!--            <td>@twitter</td>-->
<!--            <td>@twitter</td>-->
<!--            <td>-->
<!--              <div>-->
<!--                <button class="btn btn-secondary m-1">Edit</button>-->
<!--                <button class="btn btn-danger" data-bs-target="#exampleModal" data-bs-toggle="modal">Delete</button>-->
<!--              </div>-->
<!--            </td>-->
<!--          </tr>-->
          </tbody>
        </table>
      </div>
    </div>
  </div>

</template>

<script setup>
import PermissionRow from "./PermissionRow.vue";
import {useRouter} from "vue-router";

const props = defineProps(['data'])
const emit = defineEmits(['onEditRow', 'onDeleteRow'])

const router = useRouter();

function onNewPermission() {
  router.push(`/permission`);
}

</script>

<style scoped>

</style>