<template>
  <div>
    <h2>Customer</h2>
  </div>
  <table class="selection">
    <thead>
      <tr>
        <th>Number</th>
        <th>Name</th>
        <th>Street</th>
        <th>City</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="customer in customers" :key="customer.id" class="clickable" @click="onCustomerClick(customer)">
        <td>{{ customer.number }}</td>
        <td>{{ customer.name }}</td>
        <td>{{ customer.street }}</td>
        <td>{{ customer.city }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts" setup>
import { computed, onBeforeMount } from 'vue';
import { useCustomersStore } from './customers-store';
import { useRouter } from 'vue-router';

const store = useCustomersStore();

const router = useRouter();

onBeforeMount(async () => {
  await store.loadCustomers();
});

const onCustomerClick = (customer: Customer) => {
  router.push({name: 'customerDetails', params: { id: customer.id }});
}

const customers = computed(() =>
  store.state.customers.map((c) => {
    return {
      id: c.id,
      name: c.name,
      number: c.number,
      street: c.street,
      city: `${c.zipCode} ${c.city}`,
      onCustomerClick
    };
  }),
);
</script>
<style lang="scss"></style>
