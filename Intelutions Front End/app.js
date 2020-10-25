var app = new Vue({
    el: '#app',
    data: {
        errors:[],
        info: '',
        NombreEmpleado: '',
        ApellidosEmpleado: '',
        TipoPermiso: '',
        FechaPermiso: '',

        editForm: {
            errors: [],
            Id: '',
            NombreEmpleado: '',
            ApellidosEmpleado: '',
            TipoPermiso: '',
            FechaPermiso: '',
        },
        deleteForm: {
            Id: ''
        }
    },
    created: function () {
        var that = this;
        axios.get('https://localhost:44378/api/Permisos/List')
            .then(function (response) {
                that.info = response.data;
            })
            .catch(function (error) {
                console.log(error);
            });
    },
    methods: {
        modalUpdate: function(item){
            this.editForm.Id = item.id;
            this.editForm.NombreEmpleado = item.nombreEmpleado;
            this.editForm.ApellidosEmpleado = item.apellidosEmpleado;
            this.editForm.TipoPermiso = item.tipoPermiso;
            this.editForm.FechaPermiso = moment(item.fechaPermiso).format('yyyy-MM-DD');
            
            $('#updateModal').modal('show');
            
        },
        modalDelete: function(id){
            this.deleteForm.Id = id;
            $('#deleteModal').modal('show');
        },
        FormOk: function () {
            this.errors = [];

            if (!this.NombreEmpleado) {
                this.errors.push("El nombre del empleado es obligatorio.");
            }

            if (!this.ApellidosEmpleado) {
                this.errors.push("El apellido del empleado es obligatorio.");
            }

            if (!this.TipoPermiso) {
                this.errors.push("El tipo de permiso es obligatorio.");
            }

            if (!this.FechaPermiso) {
                this.errors.push("La fecha de permiso es obligatoria.");
            }
            if(this.errors.length > 0)
                return false;
            return true;
        },

        FormEditOk: function () {
            this.editForm.errors = [];

            if (!this.editForm.NombreEmpleado) {
                this.editForm.errors.push("El nombre del empleado es obligatorio.");
            }

            if (!this.editForm.ApellidosEmpleado) {
                this.editForm.errors.push("El apellido del empleado es obligatorio.");
            }

            if (!this.editForm.TipoPermiso) {
                this.editForm.errors.push("El tipo de permiso es obligatorio.");
            }

            if (!this.editForm.FechaPermiso) {
                this.editForm.errors.push("La fecha de permiso es obligatoria.");
            }

            if(this.editForm.errors.length > 0)
                return false;

            return true;
        },

        insert: function (NombreEmpleado, ApellidosEmpleado, TipoPermiso, FechaPermiso) {
            if(this.FormOk())
            {
                var model = {
                    NombreEmpleado: NombreEmpleado,
                    ApellidosEmpleado: ApellidosEmpleado,
                    TipoPermiso: TipoPermiso,
                    FechaPermiso: FechaPermiso
                };
    
                let axiosConfig = {
                    headers: {
                        'Content-Type': 'application/json;',
                    }
                };
    
                axios.post("https://localhost:44378/api/Permisos/Create", model, axiosConfig).then((result) => {
                    console.log(result);
                    location.reload();
                })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        update: function (Id, NombreEmpleado, ApellidosEmpleado, TipoPermiso, FechaPermiso) {
            if(this.FormEditOk())
            {
                var model = {
                    Id : Id,
                    NombreEmpleado: NombreEmpleado,
                    ApellidosEmpleado: ApellidosEmpleado,
                    TipoPermiso: TipoPermiso,
                    FechaPermiso: FechaPermiso
                };
    
                let axiosConfig = {
                    headers: {
                        'Content-Type': 'application/json;',
                    }
                };
    
                axios.put("https://localhost:44378/api/Permisos/Update", model, axiosConfig).then((result) => {
                    console.log(result);
                    location.reload();
                })
                    .catch(function (error) {
                        console.log(error);
                    });
            }
        },
        deleteData: function(id){
            let axiosConfig = {
                headers: {
                    'Content-Type': 'application/json;',
                }
            };
            axios.delete("https://localhost:44378/api/Permisos/Delete/" + id, axiosConfig).then((result) => {
                console.log(result);
                location.reload();
            })
                .catch(function (error) {
                    console.log(error);
                });
        }
    },
    filters: {
        format: function (date) {
            return moment(date).format('DD/MM/YYYY');
        }
    }
})