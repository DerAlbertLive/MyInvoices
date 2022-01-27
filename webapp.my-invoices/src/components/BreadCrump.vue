<script lang="ts" setup>
import { computed } from '@vue/reactivity';
import { useRoute, useRouter } from 'vue-router';

type Crump = {
  name: string;
  caption: string;
  params: unknown;
};

const router = useRouter();

const breadCrumps = computed(() => {
  const crumps: Array<Crump> = [];

  const root = router.getRoutes().filter((r) => r.path === '/')[0];

  crumps.push({
    params: {},
    name: root.name ? root.name.toString() : '/',
    caption: root.meta.nav?.caption ?? 'Missing Caption',
  });

  const route = router.currentRoute.value;
  let pathArray = router.currentRoute.value.path.split('/');
  pathArray.shift();

  pathArray.forEach((value, index) => {
    const matched = route.matched[index];
    if (!matched) {
      return;
    }
    if (crumps[crumps.length - 1].name === matched.name) {
      return;
    }
    const name = matched.name ? matched.name.toString() : '';
    let params = {};
    if (route.name === name) {
      params = route.params;
    }
    const caption = matched.meta.nav?.caption ?? value;
    crumps.push({
      name: name,
      caption: caption,
      params: params,
    });
  });
  return crumps;
});
</script>

<template>
  <div class="container">
    <div v-for="(crump, idx) in breadCrumps" :key="crump.name">
      <router-link :to="{ name: crump.name, params: crump.params }">
        {{ crump.caption }}
      </router-link>
      <span v-if="idx !== breadCrumps.length - 1">&nbsp;&gt;&nbsp;</span>
    </div>
  </div>
</template>
<style scoped lang="scss">
@tailwind components;
.container {
  @apply border-b-2;
  border-color: var(--topnav-color-background);
  div {
    @apply inline text-slate-400;
    a:hover {
      @apply text-slate-600;
      text-decoration: underline;
    }
    span {
      color: var(--topnav-color-background);
    }
  }
}
</style>
