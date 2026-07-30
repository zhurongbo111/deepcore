import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/HomeView.vue'
import MainLayout from '@/layouts/MainLayout.vue'
import { useAuthGuard } from './authGuard.ts';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: 'home',
      component: MainLayout,
      meta: { requiresAuth: true },
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
          meta: {
            requiresAuth: true
          }
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
        {
          path: '/demo/success',
          name: 'success',
          component: () => import('../views/demo/SuccessPage.vue'),
        },
        {
          path: '/demo/error',
          name: 'error',
          component: () => import('../views/demo/ErrorPage.vue'),
        },
        {
          path: '/demo/404',
          name: 'not-found',
          component: () => import('../views/demo/NotFound.vue'),
        },
      ],
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginPage.vue'),
    },
  ],
});

useAuthGuard(router);

export default router
