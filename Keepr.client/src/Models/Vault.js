export class Vault{
  constructor(data = {}){
  this.id = data.id
  this.creatorId = data.creatorId
  this.name = data.name
  this.description = data.description
  this.isPrivate = data.isPrivate
  this.creator = data.creator
  }

}