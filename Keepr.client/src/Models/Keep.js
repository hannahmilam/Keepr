export class Keep {
constructor(data = {}){
this.id = data.id
this.creatorId = data.creatorId
this.name = data.name
this.img = data.img || "https://greenlighthealth.com/wp-content/uploads/2021/03/FPO-495x400-1.gif"
this.description = data.description
this.views = data.views
this.shares = data.shares
this.keeps = data.keeps
this.creator = data.creator || {}
this.vaultKeepId = data.vaultKeepId
}
}