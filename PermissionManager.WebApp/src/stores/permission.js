import {defineStore} from "pinia";
import axios from "axios";

export const usePermissionStore = defineStore({
    id: "permission",
    state: () => ({
        permissions: [],
        permission: {},
        types: [],
        isEdit: false
    }),
    actions: {
        async load() {
            try {
                let response = await axios.get(`https://localhost:7067/api/permission/${1}/${10}`);
                let typesResponse = await axios.get(`https://localhost:7067/api/permissiontypes`);
                this.permissions = response.data
                this.types = typesResponse.data
            }
            catch (e) {
                console.log(e)                
            }
        },
        async getById(id) {
            try {
                let response = await axios.get(`https://localhost:7067/api/permission/${id}`);
                this.permission = response.data.permissionResponse
                this.types = response.data.permissionTypesReponse
                this.isEdit = true;
                console.log(this.types)
            }
            catch (e) {
                console.log(e)
            }
        },        
        async create() {
            let body = {
                firstName: this.permission.firstName,
                lastName: this.permission.lastName,
                permissionTypeId: this.permission.permissionTypeId,
                permissionDate: this.permission.permissionDate
            }

            try {
                let config = {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                let response = await axios.post(`https://localhost:7067/api/permission`, body, config);
                this.reset()
            }
            catch (e) {
                console.log(e)
            } 
        },
        async update(id) {            
            let body = {
                id: this.permission.id,
                firstName: this.permission.firstName,
                lastName: this.permission.lastName,
                permissionTypeId: this.permission.permissionTypeId,
                permissionDate: this.permission.permissionDate
            }
            console.log(id)
            try {
                let config = {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                let response = await axios.put(`https://localhost:7067/api/permission/${id}`, body, config);
                this.reset()
            } catch (e) {
                console.log(e.message)
            }
        },
        async delete() {
            try {
                let response = await axios.delete(`https://localhost:7067/api/permission/${id}`);
            } catch (e) {
                console.log(e)
            }
        },
        async reset() {
            this.permission = {}
            this.isEdit = false
        },
    },
});
