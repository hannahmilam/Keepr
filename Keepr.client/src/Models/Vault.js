export class Vault{
  constructor(data = {}){
  this.id = data.id
  this.creatorId = data.creatorId
  this.name = data.name
  this.description = data.description
  this.isPrivate = data.isPrivate
  this.creator = data.creator || {}
  this.img = data.img || "https://images.unsplash.com/photo-1616033481409-1bc22a923483?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTV8fGJhY2tncm91bmQlMjBpbWFnZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=60"
  }

}