<template>
  <div class="page">
    <header class="header">แบบทดสอบ</header>
    <div class="content">
      <form @submit.prevent="submit">
        <div class="field">
          <label>ชื่อ</label>
          <input v-model="form.name" type="text" placeholder="กรอกชื่อ" required />
        </div>

        <div class="field">
          <label>ข้อ 1) ข้อใดต่างจากข้ออื่น</label>
          <div class="choices">
            <label v-for="n in [3,5,9,11]" :key="n" class="choice">
              <input type="radio" :value="n" v-model="form.answer1" required />
              {{ n }}
            </label>
          </div>
        </div>

        <div class="field">
          <label>ข้อ 2) X + 2 = 4 จงหาค่า X</label>
          <div class="choices">
            <label v-for="n in [1,2,3,4]" :key="n" class="choice">
              <input type="radio" :value="n" v-model="form.answer2" required />
              {{ n }}
            </label>
          </div>
        </div>
        <div class="field">
            <label v-if="submitted" >คุณ {{ result.name }} สอบได้คะแนน {{ result.totalPoint }}/2 </label>
        </div>
        <div v-if="error" class="error">{{ error }}</div>
        <button v-if="submitted" class="btn-submit" @click="reset">สอบอีกครั้ง</button>
        <button v-else type="submit" class="btn-submit" :disabled="loading">
          {{ loading ? 'กำลังส่ง...' : 'ส่งคำตอบ' }}
        </button>
        
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import api from '../services/api'

const form = ref({ name: '', answer1: null, answer2: null })
const loading = ref(false)
const submitted = ref(false)
const result = ref(null)
const error = ref('')

async function submit() {
  error.value = ''
  loading.value = true
  try {
    const res = await api.SubmitTest(form.value)
    result.value = res.data
    submitted.value = true
  } catch (e) {
    error.value = 'เกิดข้อผิดพลาด กรุณาลองใหม่อีกครั้ง'
  } finally {
    loading.value = false
  }
}

function reset() {
  form.value = { name: '', answer1: null, answer2: null }
  submitted.value = false
  result.value = null
}
</script>

<style scoped>
.page { min-height: 100vh; background: #f0f2f5; }
.header { background: #2e7d32; color: #fff; padding: 14px 20px; font-size: 18px; font-weight: 600; }
.content { max-width: 520px; margin: 32px auto; background: #fff; border-radius: 8px; padding: 28px; }
.field { margin-bottom: 20px; }
.field label { display: block; font-weight: 600; margin-bottom: 8px; font-size: 14px; }
.field input[type="text"] { width: 100%; padding: 8px 10px; border: 1px solid #ccc; border-radius: 4px; font-size: 14px; box-sizing: border-box; }
.choices { display: flex; gap: 16px; }
.result { display: flex; gap: 16px; }
.choice { display: flex; align-items: center; gap: 6px; font-size: 14px; cursor: pointer; }
.btn-submit { background: #198ef5; color: #fff; border: none; border-radius: 4px; padding: 10px 24px; font-size: 14px; cursor: pointer; }
.btn-submit:disabled { opacity: 0.6; cursor: not-allowed; }
.error { color: #d32f2f; font-size: 13px; margin-bottom: 12px; }
.result { text-align: center; }
.result h3 { color: #2e7d32; margin-bottom: 12px; }
.result p { font-size: 15px; margin: 6px 0; }
.result .btn-submit { margin-top: 16px; }
</style>