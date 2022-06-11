<template>
<!--  {{ props }}-->
  <tr>
    <th scope="row">1</th>
    <td>{{ props.item.firstName }}</td>
    <td>{{ props.item.lastName }}</td>
    <td>{{ props.item.permissionType }}</td>
    <td>{{ formatDate(props.item.dateAt) }}</td>
    <td>
      <div>
        <button class="btn btn-secondary m-1" @click.prevent="emit('onEditRow', props.item)">Edit</button>
        <button class="btn btn-danger" data-bs-target="#exampleModal" data-bs-toggle="modal">Delete</button>
      </div>
    </td>
  </tr>
  <ConfirmationModal @on-confirm="emit('onDeleteRow', props.item)"/>
</template>

<script setup>

import ConfirmationModal from "./ConfirmationModal.vue";

const props = defineProps(['item'])
const emit = defineEmits(['onEditRow', 'onDeleteRow'])

function formatDate(dateString) {
  const date = new Date(dateString);
  return new Intl.DateTimeFormat('default', {dateStyle: 'long'}).format(date);
}


</script>

<style scoped>

</style>