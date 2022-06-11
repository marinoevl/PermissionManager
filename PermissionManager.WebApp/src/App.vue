<script setup>
import {RouterLink, RouterView} from "vue-router";</script>

<template>
  <header>
    <nav class="navbar navbar-expand-lg bg-light">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">Empresa X</a>
        <button aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation" class="navbar-toggler"
                data-bs-target="#navbarNav" data-bs-toggle="collapse" type="button">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div id="navbarNav" class="collapse navbar-collapse">
          <ul class="navbar-nav">
            <li class="nav-item">
              <RouterLink aria-current="page" class="nav-link active" to="/">Permissions</RouterLink>
            </li>
            <li class="nav-item">
              <a aria-current="page" class="nav-link active" href="#">Permissions</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>

  <div class="container p-1">
    <RouterView/>
  </div>
</template>

<style>

#app {
  max-width: 1280px;
  margin: 0 auto;
  padding: 2rem;

  font-weight: normal;
}
</style>
