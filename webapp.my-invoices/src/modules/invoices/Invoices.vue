<template>
  <div>
    <h2>Invoices</h2>
    <table class="mi-table w-full">
      <thead>
        <tr class="bg-orange-300 text-left">
          <th>Number</th>
          <th>Customer</th>
          <th>Project</th>
        </tr>
      </thead>
      <tbody></tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, PropType } from 'vue';

type InvoiceOverview = {
  id: number;
  customerName: string;
  projectName: string;
};

export default defineComponent({
  props: {
    invoices: {
      type: Array as PropType<InvoiceOverview[]>,
      required: false,
      default: () => []
    }
  },
  setup(props) {
    const visibleInvoices = computed(() => props.invoices);
    return {
      visibleInvoices
    };
  },
  methods: {
    addInvoice() {
      const a = this.invoices[0];
      const b = a.customerName;
    }
  }
});
</script>
<style lang="scss"></style>
