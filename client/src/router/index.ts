import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import MainLayout from '@/layouts/MainLayout.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: 'home',
      component: MainLayout,
      children: [
        {
          path: 'home',
          name: 'home',
          component: HomeView,
        },
        {
          path: '/demo/search-table',
          name: 'search-table',
          component: () => import('../views/demo/SearchTable.vue'),
        },
        {
          path: '/demo/step-form',
          name: 'step-form',
          component: () => import('../views/demo/StepForm.vue'),
        },
        {
          path: '/demo/group-form',
          name: 'group-form',
          component: () => import('../views/demo/GroupForm.vue'),
        },
        {
          path: '/demo/basic-info',
          name: 'basic-info',
          component: () => import('../views/demo/BasicInfo.vue'),
        },
      ],
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/Login.vue'),
    },
  ],
})

export default router
