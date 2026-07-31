import { createRouter, createWebHistory } from 'vue-router'
import MainLayout from '@/layouts/MainLayout.vue'
import { useAuthGuard } from './authGuard.ts';
import PlaceHolderLayout from '@/layouts/PlaceHolderLayout.vue';
import DashboardView from '@/views/DashboardView.vue';

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
          component: DashboardView,
        },
        {
          path: 'demo',
          component: PlaceHolderLayout,
          children: [
            {
              path: 'search-table',
              name: 'search-table',
              component: () => import('../views/demo/SearchTable.vue')
            },
            {
              path: 'step-form',
              name: 'step-form',
              component: () => import('../views/demo/StepForm.vue'),
            },
            {
              path: 'group-form',
              name: 'group-form',
              component: () => import('../views/demo/GroupForm.vue'),
            },
            {
              path: 'basic-info',
              name: 'basic-info',
              component: () => import('../views/demo/BasicInfo.vue'),
            },
            {
              path: 'success',
              name: 'success',
              component: () => import('../views/demo/SuccessPage.vue'),
            },
            {
              path: 'error',
              name: 'error',
              component: () => import('../views/demo/ErrorPage.vue'),
            },
            {
              path: '404',
              name: 'not-found',
              component: () => import('../views/demo/NotFound.vue'),
            },
          ]
        },
        {
          path: "products",
          name: "product-list",
          component: () => import('../views/ProductList.vue')
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
