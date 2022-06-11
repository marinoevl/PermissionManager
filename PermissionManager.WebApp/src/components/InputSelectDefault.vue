<template>
        <label class="form-label">{{ label }}</label>
        <select 
            v-bind="$attrs" 
            id="permissionType" 
            class="form-select" 
            :value="modelValue" 
            @change="$emit('update:modelValue',$event.target.value)">
          <option disabled value="">{{ placeholder }}</option>          
          <option
              v-for="option in options"
              :key="option.id"
              :value="option.id">{{ option.description }}</option>   
        </select>
</template>

<script setup>
const props = defineProps(['label', 'placeholder', 'options', 'modelValue'])

</script>

<style scoped>

</style>